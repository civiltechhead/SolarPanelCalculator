using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solar_Panel_Calculator_alternate
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void okay_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            results.Text = "==SOLAR PANEL DETAILING (PV Module)==";
            results.AppendText(Environment.NewLine + "Nominal volage, Vdc: " + Form1.instance.Nominal_voltage.Text + " V");
            results.AppendText(Environment.NewLine + "Max power point, Pm: " + Form1.instance.Max_power_point.Text + " W");
            results.AppendText(Environment.NewLine + "Max power point voltage, Vm: " + Form1.instance.Max_power_point_voltage.Text + " V");
            results.AppendText(Environment.NewLine + "Max power point current, Im: " + Form1.instance.Max_power_point_current.Text + " A");
            results.AppendText(Environment.NewLine + "Open circuit voltage, Voc: " + Form1.instance.Open_circuit_voltage.Text + " V");
            results.AppendText(Environment.NewLine + "Short circuit current, Isc: " + Form1.instance.Short_circuit_current.Text + " A");
            results.AppendText(Environment.NewLine + "Total watts from appliances per day: " + Form1.instance.total_watts_string + "W");
            results.AppendText(Environment.NewLine + "Number of panels: " + Form1.instance.no_of_panels_string + " panels");
            results.AppendText(Environment.NewLine + "Invert size: " + Form1.instance.Invert_size_string + " W");
            results.AppendText(Environment.NewLine + "Solar charge controller sizing: " + Form1.instance.solar_ctrl_string + " A at " + Form1.instance.Nominal_voltage.Text + " V or higher");
            results.AppendText(Environment.NewLine);
            results.AppendText(Environment.NewLine + "==BATTERY DETAILING==");
            results.AppendText(Environment.NewLine + "Battery rating: " + Form1.instance.Nominal_voltage.Text + " V, " + Form1.instance.battery_rating_string + " A for " + Form1.instance.Days_of_autonomy.Text + " day/s of autonomy");
            results.AppendText(Environment.NewLine + "Picked battery: " + Form1.instance.Energy_charge.Text + " Ah");
            results.AppendText(Environment.NewLine + "Numer of batteries: " + Form1.instance.no_of_battery_string + " batteries");
            results.AppendText(Environment.NewLine + "Back-up hours: " + Form1.instance.Required_backtime.Text + " hours");
            results.AppendText(Environment.NewLine + "Charging current: " + Form1.instance.charge_current_string + " A");
            results.AppendText(Environment.NewLine + "Charging time (per battery): " + Form1.instance.charge_time_string + " hours");
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Rich text file (*.rtf) | *.rtf | Plain Text File (*.txt) | *.txt";
            saveDlg.DefaultExt = "*.rtf";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            DialogResult retval = saveDlg.ShowDialog();
            if(retval == DialogResult.OK)
            {
                filename = saveDlg.FileName;
            }
            else
            {
                return;
            }

            RichTextBoxStreamType stream_type;
            if(saveDlg.FilterIndex == 2)
            {
                stream_type = RichTextBoxStreamType.PlainText;
            }
            else
            {
                stream_type = RichTextBoxStreamType.RichText;
            }

            results.SaveFile(filename, stream_type);
        }
    }
}
