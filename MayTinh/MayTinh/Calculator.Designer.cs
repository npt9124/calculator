namespace MayTinh
{
    partial class Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.display = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button01 = new System.Windows.Forms.Button();
            this.button02 = new System.Windows.Forms.Button();
            this.button03 = new System.Windows.Forms.Button();
            this.button06 = new System.Windows.Forms.Button();
            this.button05 = new System.Windows.Forms.Button();
            this.button04 = new System.Windows.Forms.Button();
            this.button09 = new System.Windows.Forms.Button();
            this.button08 = new System.Windows.Forms.Button();
            this.button07 = new System.Windows.Forms.Button();
            this.btEqual = new System.Windows.Forms.Button();
            this.btReturn = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.btDiv = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btMinus = new System.Windows.Forms.Button();
            this.btPlus = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.ngoac1 = new System.Windows.Forms.Button();
            this.ngoac2 = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnleft = new System.Windows.Forms.Button();
            this.btnright = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPercent = new System.Windows.Forms.Button();
            this.buttonPower = new System.Windows.Forms.Button();
            this.buttonSquare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(57, 22);
            this.display.Margin = new System.Windows.Forms.Padding(4);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(446, 49);
            this.display.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button01
            // 
            this.button01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button01.Location = new System.Drawing.Point(179, 191);
            this.button01.Margin = new System.Windows.Forms.Padding(4);
            this.button01.Name = "button01";
            this.button01.Size = new System.Drawing.Size(81, 36);
            this.button01.TabIndex = 2;
            this.button01.Text = "1";
            this.button01.UseVisualStyleBackColor = true;
            this.button01.Click += new System.EventHandler(this.button1_Click);
            // 
            // button02
            // 
            this.button02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button02.Location = new System.Drawing.Point(302, 191);
            this.button02.Margin = new System.Windows.Forms.Padding(4);
            this.button02.Name = "button02";
            this.button02.Size = new System.Drawing.Size(81, 36);
            this.button02.TabIndex = 3;
            this.button02.Text = "2";
            this.button02.UseVisualStyleBackColor = true;
            this.button02.Click += new System.EventHandler(this.button2_Click);
            // 
            // button03
            // 
            this.button03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button03.Location = new System.Drawing.Point(57, 240);
            this.button03.Margin = new System.Windows.Forms.Padding(4);
            this.button03.Name = "button03";
            this.button03.Size = new System.Drawing.Size(81, 36);
            this.button03.TabIndex = 4;
            this.button03.Text = "3";
            this.button03.UseVisualStyleBackColor = true;
            this.button03.Click += new System.EventHandler(this.button3_Click);
            // 
            // button06
            // 
            this.button06.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button06.Location = new System.Drawing.Point(179, 240);
            this.button06.Margin = new System.Windows.Forms.Padding(4);
            this.button06.Name = "button06";
            this.button06.Size = new System.Drawing.Size(81, 36);
            this.button06.TabIndex = 7;
            this.button06.Text = "4";
            this.button06.UseVisualStyleBackColor = true;
            this.button06.Click += new System.EventHandler(this.button4_Click);
            // 
            // button05
            // 
            this.button05.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button05.Location = new System.Drawing.Point(302, 237);
            this.button05.Margin = new System.Windows.Forms.Padding(4);
            this.button05.Name = "button05";
            this.button05.Size = new System.Drawing.Size(81, 36);
            this.button05.TabIndex = 6;
            this.button05.Text = "5";
            this.button05.UseVisualStyleBackColor = true;
            this.button05.Click += new System.EventHandler(this.button5_Click);
            // 
            // button04
            // 
            this.button04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button04.Location = new System.Drawing.Point(57, 295);
            this.button04.Margin = new System.Windows.Forms.Padding(4);
            this.button04.Name = "button04";
            this.button04.Size = new System.Drawing.Size(81, 36);
            this.button04.TabIndex = 5;
            this.button04.Text = "6";
            this.button04.UseVisualStyleBackColor = true;
            this.button04.Click += new System.EventHandler(this.button6_Click);
            // 
            // button09
            // 
            this.button09.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button09.Location = new System.Drawing.Point(57, 344);
            this.button09.Margin = new System.Windows.Forms.Padding(4);
            this.button09.Name = "button09";
            this.button09.Size = new System.Drawing.Size(81, 36);
            this.button09.TabIndex = 10;
            this.button09.Text = "9";
            this.button09.UseVisualStyleBackColor = true;
            this.button09.Click += new System.EventHandler(this.button9_Click);
            // 
            // button08
            // 
            this.button08.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button08.Location = new System.Drawing.Point(302, 295);
            this.button08.Margin = new System.Windows.Forms.Padding(4);
            this.button08.Name = "button08";
            this.button08.Size = new System.Drawing.Size(81, 36);
            this.button08.TabIndex = 9;
            this.button08.Text = "8";
            this.button08.UseVisualStyleBackColor = true;
            this.button08.Click += new System.EventHandler(this.button8_Click);
            // 
            // button07
            // 
            this.button07.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button07.Location = new System.Drawing.Point(179, 295);
            this.button07.Margin = new System.Windows.Forms.Padding(4);
            this.button07.Name = "button07";
            this.button07.Size = new System.Drawing.Size(81, 36);
            this.button07.TabIndex = 8;
            this.button07.Text = "7";
            this.button07.UseVisualStyleBackColor = true;
            this.button07.Click += new System.EventHandler(this.button7_Click);
            // 
            // btEqual
            // 
            this.btEqual.AllowDrop = true;
            this.btEqual.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEqual.Location = new System.Drawing.Point(57, 410);
            this.btEqual.Margin = new System.Windows.Forms.Padding(4);
            this.btEqual.Name = "btEqual";
            this.btEqual.Size = new System.Drawing.Size(326, 72);
            this.btEqual.TabIndex = 13;
            this.btEqual.Text = "=";
            this.btEqual.UseVisualStyleBackColor = false;
            this.btEqual.Click += new System.EventHandler(this.btEqual_Click);
            // 
            // btReturn
            // 
            this.btReturn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReturn.Location = new System.Drawing.Point(179, 90);
            this.btReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btReturn.Name = "btReturn";
            this.btReturn.Size = new System.Drawing.Size(81, 36);
            this.btReturn.TabIndex = 12;
            this.btReturn.Text = "Clear";
            this.btReturn.UseVisualStyleBackColor = false;
            this.btReturn.Click += new System.EventHandler(this.btReturn_Click);
            // 
            // del
            // 
            this.del.BackColor = System.Drawing.Color.Red;
            this.del.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.del.Location = new System.Drawing.Point(57, 90);
            this.del.Margin = new System.Windows.Forms.Padding(4);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(81, 36);
            this.del.TabIndex = 11;
            this.del.Text = "Delete";
            this.del.UseVisualStyleBackColor = false;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // btDiv
            // 
            this.btDiv.BackColor = System.Drawing.Color.LightSalmon;
            this.btDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDiv.Location = new System.Drawing.Point(422, 368);
            this.btDiv.Margin = new System.Windows.Forms.Padding(4);
            this.btDiv.Name = "btDiv";
            this.btDiv.Size = new System.Drawing.Size(81, 49);
            this.btDiv.TabIndex = 17;
            this.btDiv.Text = ":";
            this.btDiv.UseVisualStyleBackColor = false;
            this.btDiv.Click += new System.EventHandler(this.btDiv_Click);
            // 
            // btnMul
            // 
            this.btnMul.BackColor = System.Drawing.Color.LightSalmon;
            this.btnMul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMul.Location = new System.Drawing.Point(422, 308);
            this.btnMul.Margin = new System.Windows.Forms.Padding(4);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(81, 49);
            this.btnMul.TabIndex = 16;
            this.btnMul.Text = "x";
            this.btnMul.UseVisualStyleBackColor = false;
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btMinus
            // 
            this.btMinus.BackColor = System.Drawing.Color.LightSalmon;
            this.btMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMinus.Location = new System.Drawing.Point(422, 248);
            this.btMinus.Margin = new System.Windows.Forms.Padding(4);
            this.btMinus.Name = "btMinus";
            this.btMinus.Size = new System.Drawing.Size(81, 49);
            this.btMinus.TabIndex = 15;
            this.btMinus.Text = "-";
            this.btMinus.UseVisualStyleBackColor = false;
            this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
            // 
            // btPlus
            // 
            this.btPlus.BackColor = System.Drawing.Color.LightSalmon;
            this.btPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlus.Location = new System.Drawing.Point(422, 191);
            this.btPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(81, 49);
            this.btPlus.TabIndex = 14;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = false;
            this.btPlus.Click += new System.EventHandler(this.btnplus_Click);
            // 
            // button0
            // 
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button0.Location = new System.Drawing.Point(57, 191);
            this.button0.Margin = new System.Windows.Forms.Padding(4);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(81, 36);
            this.button0.TabIndex = 18;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // ngoac1
            // 
            this.ngoac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoac1.Location = new System.Drawing.Point(179, 344);
            this.ngoac1.Margin = new System.Windows.Forms.Padding(4);
            this.ngoac1.Name = "ngoac1";
            this.ngoac1.Size = new System.Drawing.Size(81, 36);
            this.ngoac1.TabIndex = 19;
            this.ngoac1.Text = "(";
            this.ngoac1.UseVisualStyleBackColor = true;
            this.ngoac1.Click += new System.EventHandler(this.ngoac1_Click);
            // 
            // ngoac2
            // 
            this.ngoac2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoac2.Location = new System.Drawing.Point(302, 344);
            this.ngoac2.Margin = new System.Windows.Forms.Padding(4);
            this.ngoac2.Name = "ngoac2";
            this.ngoac2.Size = new System.Drawing.Size(81, 36);
            this.ngoac2.TabIndex = 20;
            this.ngoac2.Text = ")";
            this.ngoac2.UseVisualStyleBackColor = true;
            this.ngoac2.Click += new System.EventHandler(this.ngoac2_Click);
            // 
            // dot
            // 
            this.dot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dot.Location = new System.Drawing.Point(422, 141);
            this.dot.Margin = new System.Windows.Forms.Padding(4);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(81, 36);
            this.dot.TabIndex = 21;
            this.dot.Text = ".";
            this.dot.UseVisualStyleBackColor = true;
            this.dot.Click += new System.EventHandler(this.dot_Click);
            // 
            // btnleft
            // 
            this.btnleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnleft.Location = new System.Drawing.Point(302, 90);
            this.btnleft.Margin = new System.Windows.Forms.Padding(4);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(81, 36);
            this.btnleft.TabIndex = 25;
            this.btnleft.Text = "<";
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // btnright
            // 
            this.btnright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnright.Location = new System.Drawing.Point(422, 90);
            this.btnright.Margin = new System.Windows.Forms.Padding(4);
            this.btnright.Name = "btnright";
            this.btnright.Size = new System.Drawing.Size(81, 36);
            this.btnright.TabIndex = 26;
            this.btnright.Text = ">";
            this.btnright.UseVisualStyleBackColor = true;
            this.btnright.Click += new System.EventHandler(this.btnright_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.BackColor = System.Drawing.Color.LightSalmon;
            this.btnRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevert.Location = new System.Drawing.Point(422, 431);
            this.btnRevert.Margin = new System.Windows.Forms.Padding(4);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(81, 47);
            this.btnRevert.TabIndex = 27;
            this.btnRevert.Text = "- / +";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Click += new System.EventHandler(this.MinusPlus);
            // 
            // buttonPercent
            // 
            this.buttonPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPercent.Location = new System.Drawing.Point(57, 141);
            this.buttonPercent.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPercent.Name = "buttonPercent";
            this.buttonPercent.Size = new System.Drawing.Size(81, 36);
            this.buttonPercent.TabIndex = 30;
            this.buttonPercent.Text = "%";
            this.buttonPercent.UseVisualStyleBackColor = true;
            this.buttonPercent.Click += new System.EventHandler(this.buttonPercent_Click);
            // 
            // buttonPower
            // 
            this.buttonPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPower.Location = new System.Drawing.Point(302, 141);
            this.buttonPower.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(81, 36);
            this.buttonPower.TabIndex = 29;
            this.buttonPower.Text = "^";
            this.buttonPower.UseVisualStyleBackColor = true;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // buttonSquare
            // 
            this.buttonSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSquare.Location = new System.Drawing.Point(179, 141);
            this.buttonSquare.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSquare.Name = "buttonSquare";
            this.buttonSquare.Size = new System.Drawing.Size(81, 36);
            this.buttonSquare.TabIndex = 28;
            this.buttonSquare.Text = "√";
            this.buttonSquare.UseVisualStyleBackColor = true;
            this.buttonSquare.Click += new System.EventHandler(this.buttonSquare_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 576);
            this.Controls.Add(this.buttonPercent);
            this.Controls.Add(this.buttonPower);
            this.Controls.Add(this.buttonSquare);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnright);
            this.Controls.Add(this.btnleft);
            this.Controls.Add(this.dot);
            this.Controls.Add(this.ngoac2);
            this.Controls.Add(this.ngoac1);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.btDiv);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btMinus);
            this.Controls.Add(this.btPlus);
            this.Controls.Add(this.btEqual);
            this.Controls.Add(this.btReturn);
            this.Controls.Add(this.del);
            this.Controls.Add(this.button09);
            this.Controls.Add(this.button08);
            this.Controls.Add(this.button07);
            this.Controls.Add(this.button06);
            this.Controls.Add(this.button05);
            this.Controls.Add(this.button04);
            this.Controls.Add(this.button03);
            this.Controls.Add(this.button02);
            this.Controls.Add(this.button01);
            this.Controls.Add(this.display);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Calculator";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button01;
        private System.Windows.Forms.Button button02;
        private System.Windows.Forms.Button button03;
        private System.Windows.Forms.Button button06;
        private System.Windows.Forms.Button button05;
        private System.Windows.Forms.Button button04;
        private System.Windows.Forms.Button button09;
        private System.Windows.Forms.Button button08;
        private System.Windows.Forms.Button button07;
        private System.Windows.Forms.Button btEqual;
        private System.Windows.Forms.Button btReturn;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btMinus;
        private System.Windows.Forms.Button btPlus;
        internal System.Windows.Forms.Button btDiv;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button ngoac1;
        private System.Windows.Forms.Button ngoac2;
        private System.Windows.Forms.Button dot;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnleft;
        private System.Windows.Forms.Button btnright;
        internal System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPercent;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Button buttonSquare;
    }
}

