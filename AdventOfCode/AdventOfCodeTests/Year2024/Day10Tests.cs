﻿using AdventOfCode.Year2024;

namespace AdventOfCodeTests.Year2024
{
    public class Day10Tests
    {
        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveTestInput()
        {
            TrailFinder.SumTrailScores(_puzzleTestInput, true).Should().Be(36);
        }

        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveInput()
        {
            TrailFinder.SumTrailScores(_puzzleInput, true).Should().Be(489);
        }

        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveTestInputPart2()
        {
            TrailFinder.SumTrailScores(_puzzleTestInput).Should().Be(81);
        }

        [Test]
        public void DiskCompactor_GetChecksum_ShouldSolveInputPart2()
        {
            TrailFinder.SumTrailScores(_puzzleInput).Should().Be(1086);
        }

        private const string _puzzleTestInput = "89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732";

        private const string _puzzleInput =
"1237651012319765432345545498010145891010\r\n0348943105408894001056654584321036712329\r\n9432342236717433145677723675490121903478\r\n8541051549826522238988812106789030876569\r\n7650760678434011032349900125699845686788\r\n6789898730569545601456987234016768798697\r\n4372123621078438780767076543223609894556\r\n5201014532321029892898123456104510983045\r\n6102306545452310121234010767040125672130\r\n7985430696101402100765109898234534343421\r\n8976521787210569011843210982129653254321\r\n8907823474389678123954301011018762169870\r\n7010910567478012335869832109800121078765\r\n6327823498565723546778789236789630989034\r\n5436910989367874695219654345676547876123\r\n6785403873456965784301105654565670945210\r\n5690342762106543287012234787654981234678\r\n4301201659014690196543989898943272221589\r\n5210112348323787017432170101032102100450\r\n1290010167654896528903061232589043678321\r\n0381201233210743434012354345672154509100\r\n5470300344984652143023403456983893210234\r\n6565415455675430032110512987870765210985\r\n7432326966556721243329601070121894387876\r\n8901457877876898358478732112434721296901\r\n9450962340945876569569540003965780105432\r\n2365871651232903478757651654875698987321\r\n1671010787891212349808932787034567076670\r\n0982107896500301256710149890123498125583\r\n1210212783410450901223456781210321034492\r\n0398347894323467814345069890323498503301\r\n3457656321301556030196178765432567412212\r\n6569845490219698123287234076781064565801\r\n7078780185428787654876543189899873278921\r\n8129698276538988140989812278734765103210\r\n9234567345445679031256701345625654014765\r\n0103216548765678120349810566010103425894\r\n0987607239854581234569809870987912436723\r\n1234568120123290107678712561296876543010\r\n2109879011234103238932103450345689832123";
    }
}