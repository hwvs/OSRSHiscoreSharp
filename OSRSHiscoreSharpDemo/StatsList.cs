using OSRSHiscoreSharp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;

namespace OSRSHiscoreSharpDemo
{
    public class StatsList : ObservableCollection<HiscoreSingleRecordView>
    {
        public StatsList() : base()
        {
            Func<string[], HiscoreSingleRecordView.RecordCategory, SolidColorBrush, bool> initSkillIcons = (names,category,background) =>
            {
                foreach (var skillName in names)
                {
                    var r = new HiscoreSingleRecordView(new HiscoreSingleRecord());
                    r.Category = category;
                    r.PropertyName = skillName;
                    //r.ImagePath = $"images\\{r.Category}\\{r.Name}.png";
                    r.ImagePath = $"/OSRSHiscoreSharpDemo;component/images/{r.Category.ToString()}/{r.PropertyName}.png";
                    r.PropertyNameColor = background;

                    Add(r);
                }
                return true;
            };


            initSkillIcons(HiscoreConstants.SKILL_NAMES, HiscoreSingleRecordView.RecordCategory.Skills, new SolidColorBrush(Color.FromArgb(255, 0x11, 0x11, 0x11)));
            initSkillIcons(HiscoreConstants.BOUNTY_HUNTER_NAMES, HiscoreSingleRecordView.RecordCategory.Bounty_Hunter, new SolidColorBrush(Color.FromArgb(255, 0x3e, 0x1e, 0x2e)));
            initSkillIcons(HiscoreConstants.LEAGUE_NAMES, HiscoreSingleRecordView.RecordCategory.League, new SolidColorBrush(Color.FromArgb(255, 0x11, 0x11, 0x11)));
            initSkillIcons(HiscoreConstants.CLUE_NAMES, HiscoreSingleRecordView.RecordCategory.Clues, new SolidColorBrush(Color.FromArgb(255, 0x3e, 0x3e, 0x1e)));
            initSkillIcons(HiscoreConstants.MINIGAME_NAMES, HiscoreSingleRecordView.RecordCategory.Minigames, new SolidColorBrush(Color.FromArgb(255, 0x1e, 0x3e, 0x2e)));
            initSkillIcons(HiscoreConstants.BOSS_NAMES, HiscoreSingleRecordView.RecordCategory.Bosses, new SolidColorBrush(Color.FromArgb(255, 0x1e, 0x1e, 0x3e)));

        }
    }

    public class HiscoreSingleRecordView : INotifyPropertyChanged
    {
        private string _rank = "";
        public string Rank { get { return _rank;  } set
            {
                _rank = Convert.ToInt64(value) >= 0 ? value.ToString() : "";
                NotifyPropertyChanged("Rank");
            }
        }
        private string _value = "";
        public string Value
        {
            get { return _value.ToString(); }
            set
            {
                _value = Convert.ToInt64(value) >= 0 ? value.ToString() : "";
                NotifyPropertyChanged("Value");
            }
        }
        private string _extra = "";
        public string Extra
        {
            get { return _extra.ToString(); }
            set
            {
                _extra = Convert.ToInt64(value) >= 0 ? value.ToString() : "";
                NotifyPropertyChanged("Extra");
            }
        }

        public HiscoreSingleRecordView(HiscoreSingleRecord record)
        {
            this.Rank = record.Rank.ToString();
            this.Value = record.Value.ToString();
            this.Extra = record.Extra.ToString();
        }

        public enum RecordCategory
        {
            Skills,
            Minigames,
            League,
            Bounty_Hunter,
            Clues,
            Bosses
        }
        public RecordCategory Category { get; set; }

        public string PropertyName { get; internal set; }
        public SolidColorBrush PropertyNameColor { get; set; } = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        public string ImagePath { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GetCategoryName()
        {
            return Category.ToString().Replace("_"," "); //Messy, fix this
        }

        public static string GetCSVHeader()
        {
            return "Name,Category,Rank,Value,XP";
        }
        public string GetCSVLine()
        {
            return $"{this.PropertyName},{this.Category},{this.Rank},{this.Value},{this.Extra}";
        }



    }

}
