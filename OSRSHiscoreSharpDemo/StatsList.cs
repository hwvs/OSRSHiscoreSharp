using OSRSHiscoreSharp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OSRSHiscoreSharpDemo
{
    public class StatsList : ObservableCollection<HiscoreSingleRecordView>
    {
        public StatsList() : base()
        {
            Func<string[], HiscoreSingleRecordView.RecordCategory, bool> initSkillIcons = (names,category) =>
            {
                foreach (var skillName in names)
                {
                    var r = new HiscoreSingleRecordView(new HiscoreSingleRecord());
                    r.Category = category;
                    r.PropertyName = skillName;
                    //r.ImagePath = $"images\\{r.Category}\\{r.Name}.png";
                    r.ImagePath = $"/OSRSHiscoreSharpDemo;component/images/{r.Category.ToString()}/{r.PropertyName}.png";

                    Add(r);
                }
                return true;
            };


            initSkillIcons(HiscoreConstants.SKILL_NAMES, HiscoreSingleRecordView.RecordCategory.Skills);
            initSkillIcons(HiscoreConstants.BOUNTY_HUNTER_NAMES, HiscoreSingleRecordView.RecordCategory.Bounty_Hunter);
            initSkillIcons(HiscoreConstants.LEAGUE_NAMES, HiscoreSingleRecordView.RecordCategory.League);
            initSkillIcons(HiscoreConstants.CLUE_NAMES, HiscoreSingleRecordView.RecordCategory.Clues);
            initSkillIcons(HiscoreConstants.MINIGAME_NAMES, HiscoreSingleRecordView.RecordCategory.Minigames);
            initSkillIcons(HiscoreConstants.BOSS_NAMES, HiscoreSingleRecordView.RecordCategory.Bosses);

        }
    }

    public class HiscoreSingleRecordView : INotifyPropertyChanged
    {
        private long _rank = -1;
        public long Rank { get { return _rank;  } set
            {
                _rank = value;
                NotifyPropertyChanged("Rank");
            }
        }
        private long _value = -1;
        public long Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }
        private long _extra = -1;
        public long Extra
        {
            get { return _extra; }
            set
            {
                _extra = value;
                NotifyPropertyChanged("Extra");
            }
        }

        public HiscoreSingleRecordView(HiscoreSingleRecord record)
        {
            this.Rank = record.Rank;
            this.Value = record.Value;
            this.Extra = record.Extra;
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

    }

}
