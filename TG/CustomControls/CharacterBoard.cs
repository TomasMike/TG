using System.Drawing;
using System.Windows.Forms;

namespace TG.CustomControls
{
    public partial class CharacterBoard : UserControl
    {
        public CharacterBoard()
        {
            InitializeComponent();
            var myControls = new ControlCollection(this);
            myControls.Add(NameLabel);
            myControls.Add(AggresionLabel);
            myControls.Add(CourageLabel);
            myControls.Add(PracticalityLabel);
            myControls.Add(EmpathyLabel);
            myControls.Add(CautionLabel);
            myControls.Add(SpiritualityLabel);
            myControls.Add(EnergyLabel);
            myControls.Add(HealthLabel);
            myControls.Add(TerrorLabel);
            myControls.Add(FoodLabel);
            myControls.Add(ReputationLabel);
            myControls.Add(WealthLabel);
            myControls.Add(ExperienceLabel);
            myControls.Add(MagicLabel);

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
            AggresionLabel.Text = "Aggresion";
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

            for (int i = 0; i < myControls.Count; i++)
            {
                myControls[i].Size = new Size(20,50);
                myControls[i].Location = new Point(10 + i*10,10);
            }
        }

        public CharacterBoard(Player p):base()
        {
            this.HealthValue.DataBindings.Add(new Binding("Text",this.AttachedPlayer.Character.CurrentHealth,"Health"));
        }

        private Label NameLabel;
        private Label AggresionLabel;
        private Label CourageLabel;
        private Label PracticalityLabel;
        private Label EmpathyLabel;
        private Label CautionLabel;
        private Label SpiritualityLabel;
        private Label EnergyLabel;
        private Label HealthLabel;
        private Label TerrorLabel;

        private Label FoodLabel;
        private Label ReputationLabel;
        private Label WealthLabel;
        private Label ExperienceLabel;
        private Label MagicLabel;

        private Label NameValue;
        private Label AggresionValue;
        private Label CourageValue;
        private Label PracticalityValue;
        private Label EmpathyValue;
        private Label CautionValue;
        private Label SpiritualityValue;
        private Label EnergyValue;
        private Label HealthValue;
        private Label TerrorValue;

        private Label FoodValue;
        private Label ReputationValue;
        private Label WealthValue;
        private Label ExperienceValue;
        private Label MagicValue;

        public Player AttachedPlayer;
    }
}
