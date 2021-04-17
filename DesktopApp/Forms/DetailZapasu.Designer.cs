using System.ComponentModel;

namespace DesktopApp.Forms
{
    partial class DetailZapasu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbrozhodci = new System.Windows.Forms.TextBox();
            this.tbdatum = new System.Windows.Forms.TextBox();
            this.tbdomaciskore = new System.Windows.Forms.TextBox();
            this.tbhosteskore = new System.Windows.Forms.TextBox();
            this.tbdomaci = new System.Windows.Forms.TextBox();
            this.tbhoste = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrozhodci
            // 
            this.tbrozhodci.Location = new System.Drawing.Point(26, 96);
            this.tbrozhodci.Name = "tbrozhodci";
            this.tbrozhodci.Size = new System.Drawing.Size(100, 20);
            this.tbrozhodci.TabIndex = 0;
            // 
            // tbdatum
            // 
            this.tbdatum.Location = new System.Drawing.Point(643, 20);
            this.tbdatum.Name = "tbdatum";
            this.tbdatum.Size = new System.Drawing.Size(132, 20);
            this.tbdatum.TabIndex = 1;
            // 
            // tbdomaciskore
            // 
            this.tbdomaciskore.Location = new System.Drawing.Point(265, 165);
            this.tbdomaciskore.Name = "tbdomaciskore";
            this.tbdomaciskore.Size = new System.Drawing.Size(100, 20);
            this.tbdomaciskore.TabIndex = 2;
            // 
            // tbhosteskore
            // 
            this.tbhosteskore.Location = new System.Drawing.Point(411, 165);
            this.tbhosteskore.Name = "tbhosteskore";
            this.tbhosteskore.Size = new System.Drawing.Size(100, 20);
            this.tbhosteskore.TabIndex = 3;
            // 
            // tbdomaci
            // 
            this.tbdomaci.Location = new System.Drawing.Point(135, 253);
            this.tbdomaci.Name = "tbdomaci";
            this.tbdomaci.Size = new System.Drawing.Size(100, 20);
            this.tbdomaci.TabIndex = 4;
            // 
            // tbhoste
            // 
            this.tbhoste.Location = new System.Drawing.Point(536, 253);
            this.tbhoste.Name = "tbhoste";
            this.tbhoste.Size = new System.Drawing.Size(99, 20);
            this.tbhoste.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rozhodčí";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(339, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(414, 288);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(339, 150);
            this.dataGridView2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label2.Location = new System.Drawing.Point(237, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Domácí skóre";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label3.Location = new System.Drawing.Point(411, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hosté skóre";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label4.Location = new System.Drawing.Point(135, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Domácí";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label5.Location = new System.Drawing.Point(549, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hosté";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label6.Location = new System.Drawing.Point(572, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Datum";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "zpět";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 39);
            this.label7.TabIndex = 15;
            this.label7.Text = "Detail zápasu";
            // 
            // DetailZapasu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbhoste);
            this.Controls.Add(this.tbdomaci);
            this.Controls.Add(this.tbhosteskore);
            this.Controls.Add(this.tbdomaciskore);
            this.Controls.Add(this.tbdatum);
            this.Controls.Add(this.tbrozhodci);
            this.Name = "DetailZapasu";
            this.Text = "DetailZapasu";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.DataGridView dataGridView2;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox tbrozhodci;
        private System.Windows.Forms.TextBox tbdatum;
        private System.Windows.Forms.TextBox tbdomaciskore;
        private System.Windows.Forms.TextBox tbhosteskore;
        private System.Windows.Forms.TextBox tbdomaci;
        private System.Windows.Forms.TextBox tbhoste;

        #endregion
    }
}