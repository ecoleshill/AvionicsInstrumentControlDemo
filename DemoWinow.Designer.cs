namespace AvionicsInstrumentControlDemo
{
    partial class DemoWinow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoWinow));
            this.button1 = new System.Windows.Forms.Button();
            this.verticalSpeedInstrumentControl1 = new AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl();
            this.headingIndicatorInstrumentControl1 = new AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl();
            this.horizonInstrumentControl1 = new AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl();
            this.altimeterInstrumentControl1 = new AvionicsInstrumentControlDemo.AltimeterInstrumentControl();
            this.airSpeedInstrumentControl1 = new AvionicsInstrumentControlDemo.AirSpeedIndicatorInstrumentControl();
            this.turnCoordinatorInstrumentControl1 = new AvionicsInstrumentControlDemo.TurnCoordinatorInstrumentControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // verticalSpeedInstrumentControl1
            // 
            this.verticalSpeedInstrumentControl1.Location = new System.Drawing.Point(433, 227);
            this.verticalSpeedInstrumentControl1.Name = "verticalSpeedInstrumentControl1";
            this.verticalSpeedInstrumentControl1.Size = new System.Drawing.Size(200, 200);
            this.verticalSpeedInstrumentControl1.TabIndex = 5;
            this.verticalSpeedInstrumentControl1.Text = "verticalSpeedInstrumentControl1";
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(223, 227);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(198, 200);
            this.headingIndicatorInstrumentControl1.TabIndex = 4;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // horizonInstrumentControl1
            // 
            this.horizonInstrumentControl1.Location = new System.Drawing.Point(218, 12);
            this.horizonInstrumentControl1.Name = "horizonInstrumentControl1";
            this.horizonInstrumentControl1.Size = new System.Drawing.Size(209, 211);
            this.horizonInstrumentControl1.TabIndex = 3;
            this.horizonInstrumentControl1.Text = "horizonInstrumentControl1";
            // 
            // altimeterInstrumentControl1
            // 
            this.altimeterInstrumentControl1.Location = new System.Drawing.Point(433, 18);
            this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
            this.altimeterInstrumentControl1.Size = new System.Drawing.Size(200, 200);
            this.altimeterInstrumentControl1.TabIndex = 2;
            this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
            // 
            // airSpeedInstrumentControl1
            // 
            this.airSpeedInstrumentControl1.Location = new System.Drawing.Point(12, 17);
            this.airSpeedInstrumentControl1.Name = "airSpeedInstrumentControl1";
            this.airSpeedInstrumentControl1.Size = new System.Drawing.Size(200, 200);
            this.airSpeedInstrumentControl1.TabIndex = 1;
            this.airSpeedInstrumentControl1.Text = "airSpeedInstrumentControl1";
            // 
            // turnCoordinatorInstrumentControl1
            // 
            this.turnCoordinatorInstrumentControl1.Location = new System.Drawing.Point(12, 227);
            this.turnCoordinatorInstrumentControl1.Name = "turnCoordinatorInstrumentControl1";
            this.turnCoordinatorInstrumentControl1.Size = new System.Drawing.Size(200, 200);
            this.turnCoordinatorInstrumentControl1.TabIndex = 0;
            this.turnCoordinatorInstrumentControl1.Text = "turnCoordinatorInstrumentControl1";
            // 
            // DemoWinow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verticalSpeedInstrumentControl1);
            this.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.Controls.Add(this.horizonInstrumentControl1);
            this.Controls.Add(this.altimeterInstrumentControl1);
            this.Controls.Add(this.airSpeedInstrumentControl1);
            this.Controls.Add(this.turnCoordinatorInstrumentControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DemoWinow";
            this.Text = "Standard 6-Pack";
            this.ResumeLayout(false);

        }

        #endregion

        private TurnCoordinatorInstrumentControl turnCoordinatorInstrumentControl1;
        private AirSpeedIndicatorInstrumentControl airSpeedInstrumentControl1;
        private AltimeterInstrumentControl altimeterInstrumentControl1;
        private AttitudeIndicatorInstrumentControl horizonInstrumentControl1;
        private HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private VerticalSpeedIndicatorInstrumentControl verticalSpeedInstrumentControl1;
        private System.Windows.Forms.Button button1;
    }
}

