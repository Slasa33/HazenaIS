using System.ComponentModel;

namespace DesktopApp.Forms
{
    partial class DetailHrace
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.prestupButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ulozitButton = new System.Windows.Forms.Button();
            this.postComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.klubComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(100, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(100, 132);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(100, 161);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(199, 20);
            this.textBox7.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Jméno:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Příjmení";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Klub:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rodné číslo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Heslo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // prestupButton
            // 
            this.prestupButton.Location = new System.Drawing.Point(153, 225);
            this.prestupButton.Name = "prestupButton";
            this.prestupButton.Size = new System.Drawing.Size(87, 46);
            this.prestupButton.TabIndex = 14;
            this.prestupButton.Text = "Přestup";
            this.prestupButton.UseVisualStyleBackColor = true;
            this.prestupButton.Click += new System.EventHandler(this.prestupButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 45);
            this.button2.TabIndex = 15;
            this.button2.Text = "Upravit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.upravitButton_Click);
            // 
            // ulozitButton
            // 
            this.ulozitButton.Location = new System.Drawing.Point(60, 225);
            this.ulozitButton.Name = "ulozitButton";
            this.ulozitButton.Size = new System.Drawing.Size(87, 45);
            this.ulozitButton.TabIndex = 16;
            this.ulozitButton.Text = "Uložit";
            this.ulozitButton.UseVisualStyleBackColor = true;
            this.ulozitButton.Click += new System.EventHandler(this.ulozitButton_click);
            // 
            // postComboBox
            // 
            this.postComboBox.FormattingEnabled = true;
            this.postComboBox.Location = new System.Drawing.Point(210, 131);
            this.postComboBox.Name = "postComboBox";
            this.postComboBox.Size = new System.Drawing.Size(89, 21);
            this.postComboBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(170, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Post:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 45);
            this.button4.TabIndex = 19;
            this.button4.Text = "Zpět";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.zpetButton_Click);
            // 
            // klubComboBox
            // 
            this.klubComboBox.FormattingEnabled = true;
            this.klubComboBox.Location = new System.Drawing.Point(100, 100);
            this.klubComboBox.Name = "klubComboBox";
            this.klubComboBox.Size = new System.Drawing.Size(199, 21);
            this.klubComboBox.TabIndex = 20;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(153, 226);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 44);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Smazat";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // DetailHrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 295);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.klubComboBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.postComboBox);
            this.Controls.Add(this.ulozitButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.prestupButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "DetailHrace";
            this.Text = "DetailHrace";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button deleteButton;

        private System.Windows.Forms.ComboBox klubComboBox;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.ComboBox postComboBox;

        private System.Windows.Forms.Button ulozitButton;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button prestupButton;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}