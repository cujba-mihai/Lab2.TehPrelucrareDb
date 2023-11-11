namespace Lab2.TehPrelucrareDb
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            previousBtn = new Button();
            nextBtn = new Button();
            currentRecordCount = new Label();
            dataFieldsPanel = new FlowLayoutPanel();
            updateBtn = new Button();
            deleteBtn = new Button();
            insertBtn = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(351, 23);
            comboBox1.TabIndex = 0;
            // 
            // previousBtn
            // 
            previousBtn.Location = new Point(521, 11);
            previousBtn.Name = "previousBtn";
            previousBtn.Size = new Size(75, 23);
            previousBtn.TabIndex = 1;
            previousBtn.Text = "Previous";
            previousBtn.UseVisualStyleBackColor = true;
            previousBtn.Click += previousButton_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(713, 12);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 23);
            nextBtn.TabIndex = 2;
            nextBtn.Text = "Next";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextButton_Click;
            // 
            // currentRecordCount
            // 
            currentRecordCount.AutoSize = true;
            currentRecordCount.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            currentRecordCount.Location = new Point(646, 12);
            currentRecordCount.Name = "currentRecordCount";
            currentRecordCount.Size = new Size(22, 25);
            currentRecordCount.TabIndex = 3;
            currentRecordCount.Text = "0";
            // 
            // dataFieldsPanel
            // 
            dataFieldsPanel.AutoScroll = true;
            dataFieldsPanel.Location = new Point(20, 60);
            dataFieldsPanel.Name = "dataFieldsPanel";
            dataFieldsPanel.Size = new Size(768, 378);
            dataFieldsPanel.TabIndex = 4;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(20, 462);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 23);
            updateBtn.TabIndex = 5;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(113, 462);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 23);
            deleteBtn.TabIndex = 6;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // insertBtn
            // 
            insertBtn.Location = new Point(203, 462);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(75, 23);
            insertBtn.TabIndex = 7;
            insertBtn.Text = "Insert";
            insertBtn.UseVisualStyleBackColor = true;
            insertBtn.Click += insertBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 497);
            Controls.Add(insertBtn);
            Controls.Add(deleteBtn);
            Controls.Add(updateBtn);
            Controls.Add(dataFieldsPanel);
            Controls.Add(currentRecordCount);
            Controls.Add(nextBtn);
            Controls.Add(previousBtn);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button previousBtn;
        private Button nextBtn;
        private Label currentRecordCount;
        private FlowLayoutPanel dataFieldsPanel;
        private Button updateBtn;
        private Button deleteBtn;
        private Button insertBtn;
    }
}