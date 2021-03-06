﻿using System;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class FormCalculateFlags : Form
    {
        public uint Flags { get; private set; }
 
        public FormCalculateFlags(Type data, uint value, String remove)
        {
            InitializeComponent();
            
            this._clbCalcFlags.SetFlags(data, remove);
            this._clbCalcFlags.SetCheckedItemFromFlag(value);

            this.Text = "Calculate " + data.Name;
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            this.Flags = this._clbCalcFlags.GetFlagsValue();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void _bNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _clbCalcFlags_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Flags = this._clbCalcFlags.GetFlagsValue();
            _lFlagValue.Text = "Value: " + this.Flags;
        }
        
        public static void CalculateFlags(TextBox tb,Type data, String remove)
        {
            uint val = tb.Text.ToUInt32();
            FormCalculateFlags form = new FormCalculateFlags(data, val, "");
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                tb.Text = form.Flags.ToString();
            form.Dispose();
        }
    }
}
