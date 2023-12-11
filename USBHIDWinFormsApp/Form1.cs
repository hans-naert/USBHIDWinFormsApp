using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Storage;

namespace USBHIDWinFormsApp
{
    public partial class Form1 : Form
    {
        HidDevice device;

        // Enumerate HID devices
        private async void enumerateHidDevices()
        {
            ushort vendorId = 0xC251;
            ushort productId = 0x4501; ;//0x4C01;//0x4301;//0x4511;
            ushort usagePage = 0xFF00;
            ushort usageId = 0x0001;

            // Create a selector that gets a HID device using VID/PID and a 
            // VendorDefined usage
            string selector = HidDevice.GetDeviceSelector(usagePage, usageId, vendorId, productId);

            // Enumerate devices using the selector
            var devices = await DeviceInformation.FindAllAsync(selector);

            if (devices.Count > 0)
            {
                // Open the target HID device
                device = await HidDevice.FromIdAsync(devices.ElementAt(0).Id, FileAccessMode.ReadWrite);

                // At this point the device is available to communicate with
                // So we can send/receive HID reports from it or 
                // query it for control descriptions
                USBFound.Text = "device found";
                registerForEvents();
            }
            else
            {
                // There were no HID devices that met the selector criteria
                USBFound.Text = "device not found";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void searchHidButton_Click(object sender, EventArgs e)
        {
            enumerateHidDevices();
        }

        private async void sendOutputReportAsync(byte reportId, byte firstByte)
        {
            var outputReport = device.CreateOutputReport(reportId);
            byte[] data = [reportId, firstByte];
            outputReport.Data = data.AsBuffer();
            Debug.WriteLine("Sending output report");
            uint bytesWritten = await device.SendOutputReportAsync(outputReport);
        }


        byte toggle = 0x0;

        private void sendOutputReportButton_Click(object sender, EventArgs e)
        {
            toggle = (byte)~toggle;
            sendOutputReportAsync(0x00, toggle);
        }

        private async void getNumericInputReportAsync()
        {
            var inputReport = await device.GetInputReportAsync(0x0);
            byte[] bytesRead = inputReport.Data.ToArray();
            inputReportTextBox.Text = $"[0x{bytesRead[0].ToString("X2")}, 0x{bytesRead[1].ToString("X2")}]";
        }

        private void getInputReportButton_Click(object sender, EventArgs e)
        {
            getNumericInputReportAsync();
        }

        private void Device_InputReportReceived(object sender, HidInputReportReceivedEventArgs e)
        {
            Debug.WriteLine("Input report received");
            Debug.WriteLine(e.Report.Data.ToArray());
        }

        private void registerForEvents()
        {
            device.InputReportReceived += (sender, e) =>
            {
                Debug.WriteLine("Input report received");
                var data = e.Report.Data.ToArray();
                this.Invoke(new Action(() => inputReportEventCheckBox.Checked = (data[1] == 0x01)));
                Debug.WriteLine(String.Join(" ", (Array.ConvertAll(data, b => "0x" + b.ToString("X2")))));
            };
        }

        private async void sendOutputReport64Async(byte reportId, byte firstByte)
        {
            var outputReport = device.CreateOutputReport(reportId);
            var data = new byte[65];
            data[0] = reportId;
            data[1] = firstByte;
            outputReport.Data = data.AsBuffer();
            Debug.WriteLine("Sending output report");
            uint bytesWritten = await device.SendOutputReportAsync(outputReport);
        }

        private void sendOutputReportButton64_Click(object sender, EventArgs e)
        {
            toggle = (byte)~toggle;
            sendOutputReport64Async(0x00, toggle);
        }
    }
}