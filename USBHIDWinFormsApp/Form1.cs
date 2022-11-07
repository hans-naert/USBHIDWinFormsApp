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
    }
}