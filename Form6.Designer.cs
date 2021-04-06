
namespace DataBase
{
    partial class Form6
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.route1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transportDataSet2 = new DataBase.TransportDataSet();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transportDataSet = new DataBase.TransportDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.routeTableAdapter = new DataBase.TransportDataSetTableAdapters.RouteTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.route1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.transportDataSet4 = new DataBase.TransportDataSet();
            this.route2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transportDataSet3 = new DataBase.TransportDataSet();
            this.transportDataSet1 = new DataBase.TransportDataSet();
            this.routeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.routeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.route1TableAdapter = new DataBase.TransportDataSetTableAdapters.Route1TableAdapter();
            this.route2TableAdapter = new DataBase.TransportDataSetTableAdapters.Route2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.route1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.route1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.route2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 154);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 30);
            this.button3.TabIndex = 20;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 154);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 30);
            this.button2.TabIndex = 19;
            this.button2.Text = "ОК";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.route1BindingSource;
            this.comboBox1.DisplayMember = "Type";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 110);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 24);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // route1BindingSource
            // 
            this.route1BindingSource.DataMember = "Route1";
            this.route1BindingSource.DataSource = this.transportDataSet2;
            // 
            // transportDataSet2
            // 
            this.transportDataSet2.DataSetName = "TransportDataSet";
            this.transportDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // routeBindingSource
            // 
            this.routeBindingSource.DataMember = "Route";
            this.routeBindingSource.DataSource = this.transportDataSet;
            // 
            // transportDataSet
            // 
            this.transportDataSet.DataSetName = "TransportDataSet";
            this.transportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Вид транспорта";
            // 
            // routeTableAdapter
            // 
            this.routeTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 53);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 22);
            this.textBox1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Номер остановки";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 109);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 24);
            this.button1.TabIndex = 24;
            this.button1.Text = "Выбор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.route2BindingSource;
            this.comboBox2.DisplayMember = "Number";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(202, 110);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(72, 24);
            this.comboBox2.TabIndex = 25;
            this.comboBox2.ValueMember = "Type";
            // 
            // route1BindingSource1
            // 
            this.route1BindingSource1.DataMember = "Route1";
            this.route1BindingSource1.DataSource = this.transportDataSet4;
            // 
            // transportDataSet4
            // 
            this.transportDataSet4.DataSetName = "TransportDataSet";
            this.transportDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // route2BindingSource
            // 
            this.route2BindingSource.DataMember = "Route2";
            this.route2BindingSource.DataSource = this.transportDataSet3;
            // 
            // transportDataSet3
            // 
            this.transportDataSet3.DataSetName = "TransportDataSet";
            this.transportDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transportDataSet1
            // 
            this.transportDataSet1.DataSetName = "TransportDataSet";
            this.transportDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // routeBindingSource1
            // 
            this.routeBindingSource1.DataMember = "Route";
            this.routeBindingSource1.DataSource = this.transportDataSet1;
            // 
            // routeBindingSource2
            // 
            this.routeBindingSource2.DataMember = "Route";
            this.routeBindingSource2.DataSource = this.transportDataSet1;
            // 
            // route1TableAdapter
            // 
            this.route1TableAdapter.ClearBeforeFill = true;
            // 
            // route2TableAdapter
            // 
            this.route2TableAdapter.ClearBeforeFill = true;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 204);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Name = "Form6";
            this.Text = "Добавить маршрут к остановке";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.route1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.route1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.route2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private TransportDataSet transportDataSet;
        private System.Windows.Forms.BindingSource routeBindingSource;
        private TransportDataSetTableAdapters.RouteTableAdapter routeTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private TransportDataSet transportDataSet1;
        private System.Windows.Forms.BindingSource routeBindingSource1;
        private System.Windows.Forms.BindingSource routeBindingSource2;
        private TransportDataSet transportDataSet2;
        private System.Windows.Forms.BindingSource route1BindingSource;
        private TransportDataSetTableAdapters.Route1TableAdapter route1TableAdapter;
        private System.Windows.Forms.BindingSource route2BindingSource;
        private TransportDataSet transportDataSet3;
        private TransportDataSetTableAdapters.Route2TableAdapter route2TableAdapter;
        private TransportDataSet transportDataSet4;
        private System.Windows.Forms.BindingSource route1BindingSource1;
    }
}