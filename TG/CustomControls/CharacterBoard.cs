using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TG.CustomControls
{
    public partial class CharacterBoard : UserControl
    {
        public CharacterBoard()
        {
            InitializeComponent();
            this.components = new Container();

            AutoSize = true;
            BackColor = Color.Bisque;
            var labels = new List<Control>();
            var labels2row = new List<Control>();

            labels.Add(NameLabel);
            labels.Add(EnergyLabel);
            labels.Add(HealthLabel);
            labels.Add(TerrorLabel);

            labels.Add(FoodLabel);
            labels.Add(ReputationLabel);
            labels.Add(WealthLabel);
            labels.Add(ExperienceLabel);
            labels.Add(MagicLabel);

            labels.Add(AggressionLabel);
            labels.Add(CourageLabel);
            labels.Add(PracticalityLabel);

            labels.Add(EmpathyLabel);
            labels.Add(CautionLabel);
            labels.Add(SpiritualityLabel);

            var values = new List<Control>();
            values.Add(NameValue);

            values.Add(EnergyValue);
            values.Add(HealthValue);
            values.Add(TerrorValue);

            values.Add(FoodValue);
            values.Add(ReputationValue);
            values.Add(WealthValue);
            values.Add(ExperienceValue);
            values.Add(MagicValue);

            values.Add(AggressionValue);
            values.Add(CourageValue);
            values.Add(PracticalityValue);

            values.Add(EmpathyValue);
            values.Add(CautionValue);
            values.Add(SpiritualityValue);

            //NameLabel          .
            //AggresionLabel     .
            //CourageLabel       .
            //PracticalityLabel  .
            //EmpathyLabel       .
            //CautionLabel       .
            //SpiritualityLabel  .
            //EnergyLabel        .
            //HealthLabel        .
            //TerrorLabel        .
            //FoodLabel          .
            //ReputationLabel    .
            //WealthLabel        .
            //ExperienceLabel    .
            //MagicLabel         .

            NameLabel.Text = "Name";
            AggressionLabel.Text = "Aggresion";
            CourageLabel.Text = "Courage";
            PracticalityLabel.Text = "Practicality";
            EmpathyLabel.Text = "Empathy";
            CautionLabel.Text = "Caution";
            SpiritualityLabel.Text = "Spirituality";
            EnergyLabel.Text = "Energy";
            HealthLabel.Text = "Health";
            TerrorLabel.Text = "Terror";
            FoodLabel.Text = "Food";
            ReputationLabel.Text = "Reputation";
            WealthLabel.Text = "Wealth";
            ExperienceLabel.Text = "Experience";
            MagicLabel.Text = "Magic";

            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].AutoSize = true;
                labels[i].Size = new Size(50, 20);
                labels[i].Location = new Point(10, 10 + i * 20);
                this.Controls.Add(labels[i]);
            }

            for (int i = 0; i < values.Count; i++)
            {
                values[i].Text = "1";
                values[i].AutoSize = true;
                values[i].Size = new Size(50, 20);
                values[i].Location = new Point(70, 10 + i * 20);
                this.Controls.Add(values[i]);
            }

            Size = new Size(50, 50);
            Location = new Point(10, 10);
        }

        public CharacterBoard(Player p) : this()
        {
            AttachedPlayer = p;
            bs = new BindingSource(components);
            ((ISupportInitialize)bs).BeginInit();
            bs.DataSource = AttachedPlayer;

            NameValue.DataBindings.Add("Text", AttachedPlayer, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            HealthValue.DataBindings.Add("Text", AttachedPlayer, "Character.CurrentHealth", true, DataSourceUpdateMode.OnPropertyChanged);
            EnergyValue.DataBindings.Add("Text", AttachedPlayer, "Character.CurrentEnergy", true, DataSourceUpdateMode.OnPropertyChanged);
            TerrorValue.DataBindings.Add("Text", AttachedPlayer, "Character.CurrentTerror", true, DataSourceUpdateMode.OnPropertyChanged);

            AggressionValue.DataBindings.Add("Text", AttachedPlayer, "Character.Aggression", true, DataSourceUpdateMode.OnPropertyChanged);
            CourageValue.DataBindings.Add("Text", AttachedPlayer, "Character.Courage", true, DataSourceUpdateMode.OnPropertyChanged);
            PracticalityValue.DataBindings.Add("Text", AttachedPlayer, "Character.Practicality", true, DataSourceUpdateMode.OnPropertyChanged);

            EmpathyValue.DataBindings.Add("Text", AttachedPlayer, "Character.Empathy", true, DataSourceUpdateMode.OnPropertyChanged);
            CautionValue.DataBindings.Add("Text", AttachedPlayer, "Character.Caution", true, DataSourceUpdateMode.OnPropertyChanged);
            SpiritualityValue.DataBindings.Add("Text", AttachedPlayer, "Character.Spirituality", true, DataSourceUpdateMode.OnPropertyChanged);

            FoodValue.DataBindings.Add("Text", AttachedPlayer, "Character.Food", true, DataSourceUpdateMode.OnPropertyChanged);
            ReputationValue.DataBindings.Add("Text", AttachedPlayer, "Character.Reputation", true, DataSourceUpdateMode.OnPropertyChanged);
            WealthValue.DataBindings.Add("Text", AttachedPlayer, "Character.Wealth", true, DataSourceUpdateMode.OnPropertyChanged);
            ExperienceValue.DataBindings.Add("Text", AttachedPlayer, "Character.Experience", true, DataSourceUpdateMode.OnPropertyChanged);
            MagicValue.DataBindings.Add("Text", AttachedPlayer, "Character.Magic", true, DataSourceUpdateMode.OnPropertyChanged);

            ((ISupportInitialize)bs).EndInit();
        }

        public Label NameLabel = new Label();
        public Label AggressionLabel = new Label();
        public Label CourageLabel = new Label();
        public Label PracticalityLabel = new Label();
        public Label EmpathyLabel = new Label();
        public Label CautionLabel = new Label();
        public Label SpiritualityLabel = new Label();
        public Label EnergyLabel = new Label();
        public Label HealthLabel = new Label();
        public Label TerrorLabel = new Label();
        public Label FoodLabel = new Label();
        public Label ReputationLabel = new Label();
        public Label WealthLabel = new Label();
        public Label ExperienceLabel = new Label();
        public Label MagicLabel = new Label();
        public Label NameValue = new Label();
        public Label AggressionValue = new Label();
        public Label CourageValue = new Label();
        public Label PracticalityValue = new Label();
        public Label EmpathyValue = new Label();
        public Label CautionValue = new Label();
        public Label SpiritualityValue = new Label();
        public Label EnergyValue = new Label();
        public Label HealthValue = new Label();
        public Label TerrorValue = new Label();
        public Label FoodValue = new Label();
        public Label ReputationValue = new Label();
        public Label WealthValue = new Label();
        public Label ExperienceValue = new Label();
        private Label MagicValue = new Label();

        public Player AttachedPlayer;

        public BindingSource bs;
    }
}