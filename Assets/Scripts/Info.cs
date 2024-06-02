using System;

[Serializable]
public class Info
{
    public int Malware;
    public int Social;
    public int Physic;
    public int Score;

    public string date;
    public string time;

    public Info(int malware, int social, int physic, int score)
    {
        Malware = malware;
        Social = social;
        Physic = physic;
        Score = score;

        var dt = DateTime.Now;
        date = dt.Day.ToString() + '.' + dt.Month.ToString() + '.' + dt.Year.ToString();
        time = dt.ToString("HH:mm");
    }
}