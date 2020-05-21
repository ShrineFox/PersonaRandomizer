using TGELib.IO;

namespace AtlusTableLib
{
    public static class GameManager
    {
        public static Endianness GetGameEndianness(Game game)
        {
            if (game == Game.Persona5PS3JP || game == Game.Persona5PS3NA || game == Game.Persona5PS3EU)
            {
                return Endianness.BigEndian;
            }
            return Endianness.LittleEndian;
        }
    }

    public enum Game
    {
        // 2003/02/20
        NocturneJP,

        // 2004/01/29
        NocturneManiaxJP,

        // 2004/07/15
        DigitalDevilSagaJP,

        // 2004/10/12
        NocturneManiaxNA,

        // 2005/01/27
        DigitalDevilSaga2JP,

        // 2005/04/05
        DigitalDevilSagaNA,

        // 2005/07/01
        NocturneManiaxEU,

        // 2005/10/03
        DigitalDevilSaga2NA,

        // 2006/03/02
        RaidouKuzunohaVsTheSoullessArmyJP,

        // 2006/07/13
        Persona3JP,

        // 2006/07/21
        DigitalDevilSagaEU,

        // 2006/10/20
        RaidouKuzunohaVsTheSoullessArmyNA,

        // 2007/02/16,
        DigitalDevilSaga2EU,

        // 2007/04/19
        Persona3FESJP,

        // 2007/04/27
        RaidouKuzunohaVsTheSoullessArmyEU,

        // 2007/08/14
        Persona3NA,

        // 2008/02/29
        Persona3EU,

        // 2008/04/22
        Persona3FESNA,

        // 2008/07/10
        Persona4JP,

        // 2008/10/17
        Persona3FESEU,

        // 2008/10/23
        NocturneManiaxChroniclesJP,
        RaidouKuzunohaVsKingAbaddonJP,

        // 2008/11/18
        Persona3FESAU,

        // 2008/12/09
        Persona4NA,

        // 2009/03/13
        Persona4EU,

        // 2009/05/12
        RaidouKuzunohaVsKingAbaddonNA,

        // 2009/11/01
        Persona3PortableJP,

        // 2010/07/06
        Persona3PortableNA,

        // 2010/04/29
        Persona3PortableEU,

        // 2012/06/14
        Persona4GoldenJP,

        // 2012/11/20
        Persona4GoldenNA,

        // 2013/02/22
        Persona4GoldenEU,

        // 2016/09/15
        Persona5PS3JP,
        Persona5PS4JP,

        // 2017/04/04
        Persona5PS3NA,
        Persona5PS4NA,
        Persona5PS3EU,
        Persona5PS4EU
    }
}
