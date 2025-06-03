namespace ProgrammingTechnologiesLaboratoryWork6_1;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        progressBar = new ProgressBar();
        timer = new System.Windows.Forms.Timer(components);
        labelStartTime = new Label();
        labelFinishTime = new Label();
        labelDuration = new Label();
        labelThreadId = new Label();

        // progressBar
        progressBar.Location = new Point(12, 89);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(705, 10);
        progressBar.TabIndex = 0;

        // timer
        timer.Enabled = true;
        timer.Interval = 1;
        timer.Tick += timer_Tick;

        // labelStartTime
        labelStartTime.AutoSize = true;
        labelStartTime.Location = new Point(12, 9);
        labelStartTime.Name = "labelStartTime";
        labelStartTime.Size = new Size(99, 13);
        labelStartTime.TabIndex = 1;
        labelStartTime.Text = "startTimeOfProcess";

        // labelFinishTime
        labelFinishTime.AutoSize = true;
        labelFinishTime.Location = new Point(12, 62);
        labelFinishTime.Name = "labelFinishTime";
        labelFinishTime.Size = new Size(103, 13);
        labelFinishTime.TabIndex = 2;
        labelFinishTime.Text = "finishTimeOfProcess";

        // labelDuration
        labelDuration.Location = new Point(417, 62);
        labelDuration.Name = "labelDuration";
        labelDuration.RightToLeft = RightToLeft.Yes;
        labelDuration.Size = new Size(300, 13);
        labelDuration.TabIndex = 3;
        labelDuration.Text = "durationOfProcess";

        // labelThreadId
        labelThreadId.Anchor = AnchorStyles.Right;
        labelThreadId.Location = new Point(417, 9);
        labelThreadId.Name = "labelThreadId";
        labelThreadId.RightToLeft = RightToLeft.Yes;
        labelThreadId.Size = new Size(300, 13);
        labelThreadId.TabIndex = 4;
        labelThreadId.Text = "0";

        // MainForm
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(729, 111);
        Controls.Add(labelThreadId);
        Controls.Add(labelDuration);
        Controls.Add(labelFinishTime);
        Controls.Add(labelStartTime);
        Controls.Add(progressBar);
        Name = "MainForm";
        Text = "Thread Calculator";
        ResumeLayout(false);
        PerformLayout();
    }

    private ProgressBar progressBar;
    private System.Windows.Forms.Timer timer;
    private Label labelStartTime;
    private Label labelFinishTime;
    private Label labelDuration;
    private Label labelThreadId;
} 