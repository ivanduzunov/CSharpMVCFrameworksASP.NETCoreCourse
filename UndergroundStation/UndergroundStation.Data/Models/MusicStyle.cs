namespace UndergroundStation.Data.Models
{
    using System.ComponentModel;

    public enum MusicStyle
    {
        Punk = 0,
        [Description("Hardcore Punk")] HardcorePunk = 1,
        Hardcore = 2,
        Metalcore = 3,
        [Description("Death Metal")] DeathMetal = 4,
        [Description("Black Metal")] BlackMetal = 5,
        [Description("Melodic Death Metal")] MelodicDeathMetal = 6,
        [Description("Hip-Hop")] HipHop = 7,
        Deathcore = 8,
        Reggae = 9,
        [Description("Heavy Metal")] HeavyMetal = 10,
        [Description("Power Metal")] PowerMetal = 11,
        [Description("Thrash Metal")] ThrashMetal = 12,
        [Description("New Metal")] NewMetal = 13,
        [Description("Hard Rock")] HardRock = 14,
    }
}
