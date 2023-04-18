using System.Collections;
using System.Resources;

namespace SnakeGame
{
    internal class GameData
    {

        int[] vals;
        /*
         0 = Ulockables
         1 = Normal HS
         2 = Expert HS
         3 = Master HS
         4 = Endless HS
        */

        // Tests if a value is higher than the one saved, then overwrites the save if applicable
        public void Save(int data, int value)
        {
            if (vals[data] < value) vals[data] = value;
        }

        // Gets a saved value
        public int Load(int data)
        {
            return vals[data];
        }

        // Fetches all values from the save file and puts them in an array for easy access
        public GameData()
        {
            try
            {
                using (ResourceReader SaveFile = new ResourceReader(@".\epic.gamer"))
                {
                    IDictionaryEnumerator d = SaveFile.GetEnumerator();
                    vals = new int[5];
                    for (int i = 0; i < 5; i++)
                    {
                        d.MoveNext();
                        if (d.Key.ToString() == "Unlocks") vals[0] = System.Convert.ToInt32(d.Value);
                        else if (d.Key.ToString() == "Normal") vals[1] = System.Convert.ToInt32(d.Value);
                        else if (d.Key.ToString() == "Expert") vals[2] = System.Convert.ToInt32(d.Value);
                        else if (d.Key.ToString() == "Master") vals[3] = System.Convert.ToInt32(d.Value);
                        else if (d.Key.ToString() == "Endless") vals[4] = System.Convert.ToInt32(d.Value);

                    }
                    SaveFile.Close();
                }
            }
            catch
            {
                vals = new int[] { 0, 5000, 5000, 5000, 5000 };
            }
        }

        // Writes all values to the save file
        public void Write()
        {
            using (ResourceWriter SaveFile = new ResourceWriter(@".\epic.gamer"))
            {
                SaveFile.AddResource("Unlocks", vals[0]);
                SaveFile.AddResource("Normal", vals[1]);
                SaveFile.AddResource("Expert", vals[2]);
                SaveFile.AddResource("Master", vals[3]);
                SaveFile.AddResource("Endless", vals[4]);
                SaveFile.Close();
            }
        }

    }
}
