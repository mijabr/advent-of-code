namespace AdventOfCodeTests.Year2022
{
    public class Day16XTests
    {
        [Test]
        public void ValveTunnels_CanInitialise()
        {
            var valveTunnels = new ValveTunnels(_exampleInput);

            valveTunnels.Valves["AA"].Name.Should().Be("AA");
            valveTunnels.Valves["AA"].FlowRate.Should().Be(0);
            valveTunnels.Valves["AA"].TunnelsTo.Should().BeEquivalentTo(new List<string> { "DD", "II", "BB" });

            valveTunnels.Valves["BB"].Name.Should().Be("BB");
            valveTunnels.Valves["BB"].FlowRate.Should().Be(13);
            valveTunnels.Valves["BB"].TunnelsTo.Should().BeEquivalentTo(new List<string> { "CC", "AA" });
        }

        //[Test]
        public void FindMaximumPressureReleased_ShouldFindThePuzzleAnswerForExample1()
        {
            var valveTunnels = new ValveTunnels(_exampleInput);

            var result = valveTunnels.FindMaximumPressureReleased();

            result.Should().Be(1651);
        }

        //[Test]
        public void Test_ShouldFindThePuzzleAnswerForPart1()
        {
            var valveTunnels = new ValveTunnels(_puzzleInput);

            var result = valveTunnels.FindMaximumPressureReleased();

            result.Should().Be(0);
        }

        private const string _exampleInput = "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\r\nValve BB has flow rate=13; tunnels lead to valves CC, AA\r\nValve CC has flow rate=2; tunnels lead to valves DD, BB\r\nValve DD has flow rate=20; tunnels lead to valves CC, AA, EE\r\nValve EE has flow rate=3; tunnels lead to valves FF, DD\r\nValve FF has flow rate=0; tunnels lead to valves EE, GG\r\nValve GG has flow rate=0; tunnels lead to valves FF, HH\r\nValve HH has flow rate=22; tunnel leads to valve GG\r\nValve II has flow rate=0; tunnels lead to valves AA, JJ\r\nValve JJ has flow rate=21; tunnel leads to valve II";

        private const string _puzzleInput = "Valve TM has flow rate=3; tunnels lead to valves GU, KQ, BV, MK\r\nValve BX has flow rate=0; tunnels lead to valves CD, HX\r\nValve GV has flow rate=8; tunnels lead to valves MP, SE\r\nValve OI has flow rate=0; tunnels lead to valves ZB, RG\r\nValve OY has flow rate=0; tunnels lead to valves XG, ZB\r\nValve EZ has flow rate=0; tunnels lead to valves OU, LI\r\nValve TN has flow rate=0; tunnels lead to valves DT, GU\r\nValve SE has flow rate=0; tunnels lead to valves GV, CD\r\nValve SG has flow rate=0; tunnels lead to valves XR, NK\r\nValve EB has flow rate=0; tunnels lead to valves SJ, CE\r\nValve QB has flow rate=0; tunnels lead to valves AW, MI\r\nValve GU has flow rate=0; tunnels lead to valves TN, TM\r\nValve AW has flow rate=11; tunnels lead to valves QB, IG, IK, VK\r\nValve IG has flow rate=0; tunnels lead to valves AW, SH\r\nValve MJ has flow rate=0; tunnels lead to valves IK, XR\r\nValve HX has flow rate=0; tunnels lead to valves BX, AA\r\nValve IK has flow rate=0; tunnels lead to valves MJ, AW\r\nValve QZ has flow rate=0; tunnels lead to valves AF, XG\r\nValve CV has flow rate=0; tunnels lead to valves KT, AA\r\nValve ES has flow rate=0; tunnels lead to valves BV, CD\r\nValve NK has flow rate=0; tunnels lead to valves YQ, SG\r\nValve SL has flow rate=0; tunnels lead to valves DT, XL\r\nValve RG has flow rate=17; tunnels lead to valves SJ, OI, WC\r\nValve ZB has flow rate=9; tunnels lead to valves OY, MP, DI, OX, OI\r\nValve SJ has flow rate=0; tunnels lead to valves RG, EB\r\nValve GF has flow rate=19; tunnels lead to valves DQ, SH, IH\r\nValve OU has flow rate=10; tunnels lead to valves EZ, TL, WC\r\nValve TL has flow rate=0; tunnels lead to valves OU, OX\r\nValve XG has flow rate=18; tunnels lead to valves QZ, OY\r\nValve EK has flow rate=20; tunnels lead to valves FD, MI\r\nValve BV has flow rate=0; tunnels lead to valves TM, ES\r\nValve AA has flow rate=0; tunnels lead to valves CV, HX, TR, MK, DQ\r\nValve UO has flow rate=23; tunnel leads to valve AF\r\nValve LI has flow rate=0; tunnels lead to valves EZ, CE\r\nValve MI has flow rate=0; tunnels lead to valves EK, QB\r\nValve MP has flow rate=0; tunnels lead to valves GV, ZB\r\nValve YQ has flow rate=14; tunnels lead to valves VK, MG, NK\r\nValve AF has flow rate=0; tunnels lead to valves UO, QZ\r\nValve SH has flow rate=0; tunnels lead to valves IG, GF\r\nValve FD has flow rate=0; tunnels lead to valves IH, EK\r\nValve KQ has flow rate=0; tunnels lead to valves TM, FQ\r\nValve DI has flow rate=0; tunnels lead to valves ZB, CD\r\nValve KT has flow rate=0; tunnels lead to valves DT, CV\r\nValve MG has flow rate=0; tunnels lead to valves NQ, YQ\r\nValve DQ has flow rate=0; tunnels lead to valves GF, AA\r\nValve CE has flow rate=21; tunnels lead to valves LI, EB\r\nValve MK has flow rate=0; tunnels lead to valves AA, TM\r\nValve XL has flow rate=0; tunnels lead to valves CD, SL\r\nValve OX has flow rate=0; tunnels lead to valves TL, ZB\r\nValve DT has flow rate=5; tunnels lead to valves NQ, TP, KT, SL, TN\r\nValve IH has flow rate=0; tunnels lead to valves GF, FD\r\nValve TP has flow rate=0; tunnels lead to valves XR, DT\r\nValve FQ has flow rate=0; tunnels lead to valves XR, KQ\r\nValve CD has flow rate=6; tunnels lead to valves DI, BX, XL, ES, SE\r\nValve XR has flow rate=7; tunnels lead to valves TR, FQ, TP, MJ, SG\r\nValve VK has flow rate=0; tunnels lead to valves YQ, AW\r\nValve WC has flow rate=0; tunnels lead to valves RG, OU\r\nValve TR has flow rate=0; tunnels lead to valves XR, AA\r\nValve NQ has flow rate=0; tunnels lead to valves DT, MG";
    }
}
