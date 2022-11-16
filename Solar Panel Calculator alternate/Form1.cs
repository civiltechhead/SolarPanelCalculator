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
    public partial class Form1 : Form
    {
        public static Form1 instance;
        
        // Text boxes
        public TextBox Nominal_voltage, Max_power_point, Max_power_point_voltage, Max_power_point_current, Open_circuit_voltage, Short_circuit_current, Energy_charge;
        public TextBox Required_backtime, Days_of_autonomy, PGF, Battery_loss, Depth_of_Discharge;

        // Values
        public string no_of_panels_string, Invert_size_string, solar_ctrl_string, battery_rating_string;
        public string picked_battery_string, back_up_hours_string, no_of_battery_string, back_up_string, charge_current_string;
        public string charge_time_string, no_of_appliances_string, no_of_losses_string;
        public string total_watts_string;

        public Form1()
        {
            InitializeComponent();

            instance = this;
            Nominal_voltage = NV_Vdc;
            Max_power_point = Mpp_Pm;
            Max_power_point_voltage = Mppv_Vm;
            Max_power_point_current = Mppc_Im;
            Open_circuit_voltage = Ocv_Voc;
            Short_circuit_current = Scc_Isc;
            Energy_charge = Ec_Ah;
            Required_backtime = Rbut;
            Days_of_autonomy = Doa;
            PGF = PGF_tb;
            Battery_loss = BL_tb;
            Depth_of_Discharge = DoD_tb;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Add_app_Click(object sender, EventArgs e)
        {
            decimal app_watts_val;
            decimal app_hours_val;

            if(decimal.TryParse(Power_used.Text, out app_watts_val))
            {
             if(decimal.TryParse(Hours_used.Text, out app_hours_val))
                {
                    if(String.IsNullOrEmpty(Appliance_type.Text))
                    {
                        MessageBox.Show("ERROR in input of appliance details");
                        Appliance_type.Text = String.Empty;
                        Power_used.Text = String.Empty;
                        Hours_used.Text = String.Empty;
                    }
                    else
                    {
                        Appliances.Items.Add(Appliance_type.Text);

                        decimal app_watts;
                        app_watts = Decimal.Parse(Power_used.Text);
                        Power.Items.Add(app_watts);
                        Power_used.Text = "";
                        Power_used.Focus();

                        decimal app_hours;
                        app_hours = Decimal.Parse(Hours_used.Text);
                        Time.Items.Add(app_hours);
                        Hours_used.Text = "";
                        Hours_used.Focus();

                        Appliance_type.Text = String.Empty;
                        Power_used.Text = String.Empty;
                        Hours_used.Text = String.Empty;
                    }
                }
             else
                {
                    MessageBox.Show("ERROR in input of appliance details");
                    Appliance_type.Text = String.Empty;
                    Power_used.Text = String.Empty;
                    Hours_used.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("ERROR in input of appliance details");
                Appliance_type.Text = String.Empty;
                Power_used.Text = String.Empty;
                Hours_used.Text = String.Empty;
            }
        }

        private void Time_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Clear_data_app_Click(object sender, EventArgs e)
        {
            Appliances.Items.Clear();
            Power.Items.Clear();
            Time.Items.Clear();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            decimal loss_val;

            if(decimal.TryParse(Loss_tb.Text, out loss_val))
            {
                if(String.IsNullOrEmpty(Source_tb.Text))
                {
                    MessageBox.Show("ERROR in input of energy loss details");
                    Source_tb.Text = String.Empty;
                    Loss_tb.Text = String.Empty;
                }
                else
                {
                    Source.Items.Add(Source_tb.Text);

                    decimal loss_percent;
                    loss_percent = Decimal.Parse(Loss_tb.Text);
                    Loss.Items.Add(loss_percent);

                    Source_tb.Text = String.Empty;
                    Loss_tb.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("ERROR in input of energy loss details");
                Source_tb.Text = String.Empty;
                Loss_tb.Text = String.Empty;
            }
        }

        public void clear_loss_data_Click(object sender, EventArgs e)
        {
            Source.Items.Clear();
            Loss.Items.Clear();
        }

        public void button1_Click(object sender, EventArgs e) 
        {
            int menu_1 = 0, menu_2 = 0, menu_3 = 0;

            // CHECK LISTBOXES
            if (Appliances.Items.Count == 0 || Power.Items.Count == 0 || Time.Items.Count == 0)
            {
                MessageBox.Show("ERROR due to missing data in Appliance details");
                menu_3 = 6;
            }
            else{ }

            if (Source.Items.Count == 0 || Loss.Items.Count == 0)
            {
                MessageBox.Show("ERROR due to missing data in List of energy losses");
                menu_3 = 6;
            }
            else { }

            // CHECK PV and BAT
            decimal Vdc, Pm, Vm, Im, Voc, Isc, Ah, Rbt, Day;

            if(decimal.TryParse(NV_Vdc.Text, out Vdc))
            {
                if(decimal.TryParse(Mpp_Pm.Text, out Pm))
                {
                    if(decimal.TryParse(Mppv_Vm.Text, out Vm))
                    {
                        if(decimal.TryParse(Mppc_Im.Text, out Im))
                        {
                            if(decimal.TryParse(Ocv_Voc.Text, out Voc))
                            {
                                if(decimal.TryParse(Scc_Isc.Text, out Isc))
                                {
                                    if(decimal.TryParse(Ec_Ah.Text, out Ah))
                                    {
                                        if(decimal.TryParse(Rbut.Text, out Rbt))
                                        {
                                            if(decimal.TryParse(Doa.Text, out Day))
                                            {

                                            }
                                            else
                                            {
                                                MessageBox.Show("ERROR in PV module and battery specifications");
                                                menu_1 = 6;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("ERROR in PV module and battery specifications");
                                            menu_1 = 6;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("ERROR in PV module and battery specifications");
                                        menu_1 = 6;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ERROR in PV module and battery specifications");
                                    menu_1 = 6;
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR in PV module and battery specifications");
                                menu_1 = 6;
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR in PV module and battery specifications");
                            menu_1 = 6;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR in PV module and battery specifications");
                        menu_1 = 6;
                    }
                }
                else
                {
                    MessageBox.Show("ERROR in PV module and battery specifications");
                    menu_1 = 6;
                }
            }
            else
            {
                MessageBox.Show("ERROR in PV module and battery specifications");
                menu_1 = 6;
            }

            // CHECK FIXED VALUES
            decimal PGF, BL, DoD;
            if(decimal.TryParse(PGF_tb.Text, out PGF))
            {
                if(decimal.TryParse(BL_tb.Text, out BL))
                {
                    if (decimal.TryParse(DoD_tb.Text, out DoD))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Error in Fixed values");
                        menu_2 = 6;
                    }
                }
                else
                {
                    MessageBox.Show("Error in Fixed values");
                    menu_2 = 6;
                }
            }
            else
            {
                MessageBox.Show("Error in Fixed values");
                menu_2 = 6;
            }

            // MENU PROMPT CHECK
            if(menu_1 == 6 || menu_2 == 6 || menu_3 == 6)
            {

            }
            else
            {
                // Appliances
                decimal appliance_watts_sum = 0;
                for(int a = 0; a<Power.Items.Count; a++)
                {
                    appliance_watts_sum += Convert.ToDecimal(Power.Items[a]);
                }
                decimal appliance_time_sum = 0;
                for(int b = 0; b<Time.Items.Count; b++)
                {
                    appliance_time_sum += Convert.ToDecimal(Time.Items[b]);
                }
                decimal app_watt_hrs = appliance_watts_sum * appliance_time_sum;

                // Energy losses
                decimal loss_sum = 0, loss_sum_x = 0;
                for(int c = 0; c<Loss.Items.Count; c++)
                {
                    loss_sum_x += Convert.ToDecimal(Loss.Items[c]);
                }
                loss_sum = loss_sum_x / 100 + 1;

                // App-wat-days
                decimal watt_hrs_days_x = 0;
                for(int d = 0; d<Appliances.Items.Count; d++)
                {
                    watt_hrs_days_x += Convert.ToDecimal(Power.Items[d]) * Convert.ToDecimal(Time.Items[d]);
                }
                decimal watt_hrs_days = watt_hrs_days_x*loss_sum;

                // PV modules and battery specifications
                decimal Vdc_d = 0;
                Vdc_d = Decimal.Parse(NV_Vdc.Text);

                decimal Pm_d = 0;
                Pm_d = Decimal.Parse(Mpp_Pm.Text);

                decimal Vm_d = 0;
                Vm_d = Decimal.Parse(Mppv_Vm.Text);

                decimal Im_d = 0;
                Im_d = Decimal.Parse(Mppc_Im.Text);

                decimal Voc_d = 0;
                Voc_d = Decimal.Parse(Ocv_Voc.Text);

                decimal Isc_d = 0;
                Isc_d = Decimal.Parse(Scc_Isc.Text);

                decimal Ah_d = 0;
                Ah_d = Decimal.Parse(Ec_Ah.Text);

                decimal Rbt_d = 0;
                Rbt_d = Decimal.Parse(Rbut.Text);

                decimal Day_d = 0;
                Day_d = Decimal.Parse(Doa.Text);

                // Fixed values
                decimal PGF_d = 0;
                PGF_d = Decimal.Parse(PGF_tb.Text);

                decimal BL_d = 0;
                BL_d = Decimal.Parse(BL_tb.Text);

                decimal DoD_d = 0;
                DoD_d = Decimal.Parse(DoD_tb.Text);

                // Panel values

                decimal no_of_panels = 0, watt_peak_rating = 0;
                watt_peak_rating = watt_hrs_days / PGF_d;
                no_of_panels = Math.Ceiling(watt_peak_rating/Pm_d);

                // Invert sizing

                decimal invert_size;
                decimal invertsizingvalue = Decimal.Parse(invert_sizing.Text);
                invert_size = Math.Round(appliance_watts_sum*invertsizingvalue);

                // Battery sizing

                decimal battery_capacity_denominator, battery_capacity;
                battery_capacity_denominator = BL_d*DoD_d*Vdc_d;
                battery_capacity = watt_hrs_days_x / battery_capacity_denominator * Day_d;
                decimal final_BC = Math.Ceiling(battery_capacity);

                decimal individual_BT, no_of_batteries=0, req_charge_current=0, charge_time, charging_time_add, amp_est;
                decimal reqcharge_x = Decimal.Parse(reqchargecurrent.Text);
                decimal ampereest_x = Decimal.Parse(ampereest.Text);

                individual_BT = Ah_d * Vdc_d / Rbt_d;
                no_of_batteries = Math.Ceiling(Vdc_d * Ah_d / Rbt_d);
                req_charge_current = reqcharge_x * Ah_d * no_of_batteries;
                charging_time_add = Ah_d*loss_sum;
                amp_est = ampereest_x * req_charge_current;
                charge_time = Ah_d / req_charge_current * charging_time_add;

                // Solar controller
                decimal solar_ctrl = Math.Ceiling(no_of_panels*Isc_d*loss_sum);

                // DATA SUMMARY (Transferring data to form 2)
                no_of_panels_string = Convert.ToString(no_of_panels);
                Invert_size_string = Convert.ToString(invert_size);
                solar_ctrl_string = Convert.ToString(solar_ctrl);
                battery_rating_string = Convert.ToString(final_BC);
                picked_battery_string = Convert.ToString(Ah_d);
                no_of_battery_string = Convert.ToString(no_of_batteries);
                charge_current_string = Convert.ToString(req_charge_current);
                charge_time_string = Convert.ToString(charge_time);
                total_watts_string = Convert.ToString(watt_hrs_days);

                Form2 f2 = new Form2();
                f2.Show();
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            invert_sizing.Visible = false;
            reqchargecurrent.Visible = false;
            ampereest.Visible = false;
            MaximizeBox = false;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Clear all data (This will erase everything)?", "Clear data", MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                Appliances.Items.Clear();
                Power.Items.Clear();
                Time.Items.Clear();
                Source.Items.Clear();
                Loss.Items.Clear();
                NV_Vdc.Text = String.Empty;
                Mppc_Im.Text = String.Empty;
                Mppv_Vm.Text = String.Empty;
                Mpp_Pm.Text = String.Empty;
                Ocv_Voc.Text = String.Empty;
                Scc_Isc.Text = String.Empty;
                Rbut.Text = String.Empty;
                Doa.Text = String.Empty;
                Ec_Ah.Text = String.Empty;
                PGF_tb.Text = String.Empty;
                BL_tb.Text = String.Empty;
                DoD_tb.Text = String.Empty;
            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }   
        }
    }
}
