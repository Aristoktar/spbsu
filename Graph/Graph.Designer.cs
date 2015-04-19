namespace Graph
{
    partial class Graph
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.checkBoxZoomrRecalc = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Bmp picture (*.bmp)|*.bmp";
			// 
			// checkBoxZoomrRecalc
			// 
			this.checkBoxZoomrRecalc.AutoSize = true;
			this.checkBoxZoomrRecalc.Checked = true;
			this.checkBoxZoomrRecalc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxZoomrRecalc.Location = new System.Drawing.Point(305, 343);
			this.checkBoxZoomrRecalc.Name = "checkBoxZoomrRecalc";
			this.checkBoxZoomrRecalc.Size = new System.Drawing.Size(90, 17);
			this.checkBoxZoomrRecalc.TabIndex = 0;
			this.checkBoxZoomrRecalc.Text = "Zoom Recalc";
			this.checkBoxZoomrRecalc.UseVisualStyleBackColor = true;
			// 
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxZoomrRecalc);
			this.Name = "Graph";
			this.Size = new System.Drawing.Size(464, 363);
			this.Load += new System.EventHandler(this.Graph_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.CheckBox checkBoxZoomrRecalc;
    }
}
