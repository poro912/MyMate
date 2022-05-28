namespace UserProfile
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.circleButton3 = new UserProfile.CircleButton();
            this.circlePictureBox1 = new UserProfile.CirclePictureBox();
            this.circleButton4 = new UserProfile.CircleButton();
            this.circleButton2 = new UserProfile.CircleButton();
            this.circleButton1 = new UserProfile.CircleButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.circleButton4);
            this.panel2.Controls.Add(this.circleButton2);
            this.panel2.Controls.Add(this.circleButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 80);
            this.panel2.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "call.png");
            this.imageList1.Images.SetKeyName(1, "msg.png");
            this.imageList1.Images.SetKeyName(2, "call.png");
            this.imageList1.Images.SetKeyName(3, "msg.png");
            this.imageList1.Images.SetKeyName(4, "calender.png");
            this.imageList1.Images.SetKeyName(5, "setting.jpg");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.circleButton3);
            this.panel1.Controls.Add(this.circlePictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 412);
            this.panel1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(424, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "goguma@github.com";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(370, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "git";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(424, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "goguma@naver.com";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(363, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "email";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(367, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "상태";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(424, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "고구마가 먹고싶은 하루";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(502, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "#1234";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(449, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "고구마";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageIndex = 2;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // circleButton3
            // 
            this.circleButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.circleButton3.BackColor = System.Drawing.Color.Lime;
            this.circleButton3.FlatAppearance.BorderSize = 0;
            this.circleButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton3.Location = new System.Drawing.Point(504, 128);
            this.circleButton3.Margin = new System.Windows.Forms.Padding(0);
            this.circleButton3.Name = "circleButton3";
            this.circleButton3.Size = new System.Drawing.Size(15, 15);
            this.circleButton3.TabIndex = 3;
            this.circleButton3.UseVisualStyleBackColor = false;
            this.circleButton3.Click += new System.EventHandler(this.circleButton3_Click);
            // 
            // circlePictureBox1
            // 
            this.circlePictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.circlePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(198)))), ((int)(((byte)(209)))));
            this.circlePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circlePictureBox1.ErrorImage = null;
            this.circlePictureBox1.ImageLocation = "D:\\project\\bono.jpg";
            this.circlePictureBox1.InitialImage = null;
            this.circlePictureBox1.Location = new System.Drawing.Point(426, 51);
            this.circlePictureBox1.Name = "circlePictureBox1";
            this.circlePictureBox1.Size = new System.Drawing.Size(100, 100);
            this.circlePictureBox1.TabIndex = 2;
            this.circlePictureBox1.TabStop = false;
            this.circlePictureBox1.Click += new System.EventHandler(this.circlePictureBox1_Click_1);
            // 
            // circleButton4
            // 
            this.circleButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.circleButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.circleButton4.FlatAppearance.BorderSize = 0;
            this.circleButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton4.ImageIndex = 5;
            this.circleButton4.ImageList = this.imageList1;
            this.circleButton4.Location = new System.Drawing.Point(555, 11);
            this.circleButton4.Margin = new System.Windows.Forms.Padding(0);
            this.circleButton4.Name = "circleButton4";
            this.circleButton4.Size = new System.Drawing.Size(60, 60);
            this.circleButton4.TabIndex = 2;
            this.circleButton4.TabStop = false;
            this.circleButton4.UseVisualStyleBackColor = true;
            // 
            // circleButton2
            // 
            this.circleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.circleButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.circleButton2.FlatAppearance.BorderSize = 0;
            this.circleButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton2.ImageIndex = 4;
            this.circleButton2.ImageList = this.imageList1;
            this.circleButton2.Location = new System.Drawing.Point(445, 11);
            this.circleButton2.Margin = new System.Windows.Forms.Padding(0);
            this.circleButton2.Name = "circleButton2";
            this.circleButton2.Size = new System.Drawing.Size(60, 60);
            this.circleButton2.TabIndex = 1;
            this.circleButton2.TabStop = false;
            this.circleButton2.UseVisualStyleBackColor = true;
            // 
            // circleButton1
            // 
            this.circleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.circleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.circleButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.circleButton1.FlatAppearance.BorderSize = 0;
            this.circleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleButton1.ImageIndex = 3;
            this.circleButton1.ImageList = this.imageList1;
            this.circleButton1.Location = new System.Drawing.Point(331, 11);
            this.circleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.circleButton1.Name = "circleButton1";
            this.circleButton1.Size = new System.Drawing.Size(60, 60);
            this.circleButton1.TabIndex = 0;
            this.circleButton1.TabStop = false;
            this.circleButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private CircleButton circleButton2;
        private CircleButton circleButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private CircleButton circleButton3;
        private CirclePictureBox circlePictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private CircleButton circleButton4;
    }
}

