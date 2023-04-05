
namespace InsectAutoSystem2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTemperature = new System.Windows.Forms.TextBox();
            this.tbHumidity = new System.Windows.Forms.TextBox();
            this.tbCO2 = new System.Windows.Forms.TextBox();
            this.tbNH3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnectSensor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnectScale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbScalePort = new System.Windows.Forms.ComboBox();
            this.btnConnectController = new System.Windows.Forms.Button();
            this.cbSensorPort = new System.Windows.Forms.ComboBox();
            this.cbControlPort = new System.Windows.Forms.ComboBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbBoxCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 861);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1182, 855);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbLog, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1191, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(390, 855);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 429);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 188);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "환경정보";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 6;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.label10, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.label11, 5, 1);
            this.tableLayoutPanel6.Controls.Add(this.tbTemperature, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tbHumidity, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.tbCO2, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.tbNH3, 4, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(378, 168);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(30, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "온도";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(127, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "℃";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(216, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "습도";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(313, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "%";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(30, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "CO2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(127, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "ppm";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Location = new System.Drawing.Point(217, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "NH3";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(313, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "ppm";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTemperature
            // 
            this.tbTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTemperature.Location = new System.Drawing.Point(65, 3);
            this.tbTemperature.Name = "tbTemperature";
            this.tbTemperature.ReadOnly = true;
            this.tbTemperature.Size = new System.Drawing.Size(56, 21);
            this.tbTemperature.TabIndex = 8;
            // 
            // tbHumidity
            // 
            this.tbHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHumidity.Location = new System.Drawing.Point(251, 3);
            this.tbHumidity.Name = "tbHumidity";
            this.tbHumidity.ReadOnly = true;
            this.tbHumidity.Size = new System.Drawing.Size(56, 21);
            this.tbHumidity.TabIndex = 9;
            // 
            // tbCO2
            // 
            this.tbCO2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCO2.Location = new System.Drawing.Point(65, 28);
            this.tbCO2.Name = "tbCO2";
            this.tbCO2.ReadOnly = true;
            this.tbCO2.Size = new System.Drawing.Size(56, 21);
            this.tbCO2.TabIndex = 10;
            // 
            // tbNH3
            // 
            this.tbNH3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNH3.Location = new System.Drawing.Point(251, 28);
            this.tbNH3.Name = "tbNH3";
            this.tbNH3.ReadOnly = true;
            this.tbNH3.Size = new System.Drawing.Size(56, 21);
            this.tbNH3.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "장비연결 설정";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnConnectSensor, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnConnectScale, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbScalePort, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConnectController, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.cbSensorPort, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbControlPort, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(378, 129);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "3. 제어연결";
            // 
            // btnConnectSensor
            // 
            this.btnConnectSensor.Location = new System.Drawing.Point(282, 25);
            this.btnConnectSensor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnConnectSensor.Name = "btnConnectSensor";
            this.btnConnectSensor.Size = new System.Drawing.Size(75, 22);
            this.btnConnectSensor.TabIndex = 5;
            this.btnConnectSensor.Text = "연결";
            this.btnConnectSensor.UseVisualStyleBackColor = true;
            this.btnConnectSensor.Click += new System.EventHandler(this.btnConnectSensor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. 센서연결";
            // 
            // btnConnectScale
            // 
            this.btnConnectScale.Location = new System.Drawing.Point(282, 0);
            this.btnConnectScale.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnConnectScale.Name = "btnConnectScale";
            this.btnConnectScale.Size = new System.Drawing.Size(75, 22);
            this.btnConnectScale.TabIndex = 2;
            this.btnConnectScale.Text = "연결";
            this.btnConnectScale.UseVisualStyleBackColor = true;
            this.btnConnectScale.Click += new System.EventHandler(this.btnConnectScale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "1. 저울연결";
            // 
            // cbScalePort
            // 
            this.cbScalePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbScalePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScalePort.FormattingEnabled = true;
            this.cbScalePort.Location = new System.Drawing.Point(76, 3);
            this.cbScalePort.Name = "cbScalePort";
            this.cbScalePort.Size = new System.Drawing.Size(200, 20);
            this.cbScalePort.TabIndex = 0;
            // 
            // btnConnectController
            // 
            this.btnConnectController.Location = new System.Drawing.Point(282, 53);
            this.btnConnectController.Name = "btnConnectController";
            this.btnConnectController.Size = new System.Drawing.Size(75, 23);
            this.btnConnectController.TabIndex = 8;
            this.btnConnectController.Text = "연결";
            this.btnConnectController.UseVisualStyleBackColor = true;
            this.btnConnectController.Click += new System.EventHandler(this.btnConnectController_Click);
            // 
            // cbSensorPort
            // 
            this.cbSensorPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSensorPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSensorPort.FormattingEnabled = true;
            this.cbSensorPort.Location = new System.Drawing.Point(76, 28);
            this.cbSensorPort.Name = "cbSensorPort";
            this.cbSensorPort.Size = new System.Drawing.Size(200, 20);
            this.cbSensorPort.TabIndex = 9;
            // 
            // cbControlPort
            // 
            this.cbControlPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbControlPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbControlPort.FormattingEnabled = true;
            this.cbControlPort.Location = new System.Drawing.Point(76, 53);
            this.cbControlPort.Name = "cbControlPort";
            this.cbControlPort.Size = new System.Drawing.Size(200, 20);
            this.cbControlPort.TabIndex = 10;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 623);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(384, 229);
            this.tbLog.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel5.Controls.Add(this.btnSnapshot, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnStop, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 158);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(384, 71);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSnapshot.Location = new System.Drawing.Point(282, 3);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(99, 65);
            this.btnSnapshot.TabIndex = 3;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 65);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "동작시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(103, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 65);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "동작정지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(203, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 65);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 235);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(384, 188);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "사육상자 정보";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbBoxCode, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tbWeight, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 168);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "상자번호";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBoxCode
            // 
            this.tbBoxCode.Location = new System.Drawing.Point(62, 3);
            this.tbBoxCode.Name = "tbBoxCode";
            this.tbBoxCode.ReadOnly = true;
            this.tbBoxCode.Size = new System.Drawing.Size(313, 21);
            this.tbBoxCode.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 25);
            this.label13.TabIndex = 2;
            this.label13.Text = "상자무게";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbWeight
            // 
            this.tbWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWeight.Location = new System.Drawing.Point(62, 28);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.ReadOnly = true;
            this.tbWeight.Size = new System.Drawing.Size(313, 21);
            this.tbWeight.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "누에계측시스템 - 강원도 농산물 원종장 잠사곤충";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnectScale;
        private System.Windows.Forms.ComboBox cbScalePort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnConnectSensor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnectController;
        private System.Windows.Forms.ComboBox cbSensorPort;
        private System.Windows.Forms.ComboBox cbControlPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTemperature;
        private System.Windows.Forms.TextBox tbHumidity;
        private System.Windows.Forms.TextBox tbCO2;
        private System.Windows.Forms.TextBox tbNH3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbBoxCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbWeight;
    }
}

