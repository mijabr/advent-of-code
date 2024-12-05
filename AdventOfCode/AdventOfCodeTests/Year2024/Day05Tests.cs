﻿using AdventOfCode.Year2024;

namespace AdventOfCodeTests.Year2024
{
    public class Day05Tests
    {
        [Test]
        public void ComputerMultiplier_ShouldSolveTestInput()
        {
            ManualPageOrder.FindSumOfCorrectOrders(_puzzleTestInput).Should().Be(143);
        }

        [Test]
        public void ComputerMultiplier_ShouldSolveInput()
        {
            ManualPageOrder.FindSumOfCorrectOrders(_puzzleInput).Should().Be(6242);
        }

        [Test]
        public void ComputerMultiplier_ShouldSolveTestInputPart2()
        {
            ManualPageOrder.FindSumOfIncorrectOrders(_puzzleTestInput).Should().Be(123);
        }

        [Test]
        public void ComputerMultiplier_ShouldSolveInputPart2()
        {
            ManualPageOrder.FindSumOfIncorrectOrders(_puzzleInput).Should().Be(5169);
        }

        private const string _puzzleTestInput = "47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61\r\n75|61\r\n47|29\r\n75|13\r\n53|13\r\n\r\n75,47,61,53,29\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47";

        private const string _puzzleInput =
"99|31\r\n26|21\r\n26|69\r\n69|35\r\n69|75\r\n69|95\r\n59|58\r\n59|73\r\n59|87\r\n59|94\r\n82|72\r\n82|99\r\n82|62\r\n82|91\r\n82|49\r\n65|73\r\n65|86\r\n65|59\r\n65|69\r\n65|37\r\n65|11\r\n49|71\r\n49|69\r\n49|66\r\n49|16\r\n49|31\r\n49|29\r\n49|13\r\n18|37\r\n18|27\r\n18|86\r\n18|57\r\n18|17\r\n18|14\r\n18|91\r\n18|12\r\n72|37\r\n72|66\r\n72|39\r\n72|49\r\n72|21\r\n72|11\r\n72|31\r\n72|59\r\n72|16\r\n67|81\r\n67|12\r\n67|82\r\n67|35\r\n67|99\r\n67|53\r\n67|76\r\n67|72\r\n67|37\r\n67|27\r\n11|81\r\n11|35\r\n11|94\r\n11|97\r\n11|39\r\n11|24\r\n11|15\r\n11|75\r\n11|67\r\n11|82\r\n11|17\r\n16|82\r\n16|95\r\n16|45\r\n16|17\r\n16|67\r\n16|46\r\n16|18\r\n16|85\r\n16|94\r\n16|39\r\n16|91\r\n16|15\r\n35|49\r\n35|57\r\n35|45\r\n35|78\r\n35|36\r\n35|91\r\n35|59\r\n35|12\r\n35|37\r\n35|86\r\n35|72\r\n35|62\r\n35|99\r\n87|71\r\n87|73\r\n87|95\r\n87|58\r\n87|81\r\n87|94\r\n87|46\r\n87|97\r\n87|67\r\n87|21\r\n87|35\r\n87|24\r\n87|11\r\n87|18\r\n53|13\r\n53|78\r\n53|58\r\n53|54\r\n53|16\r\n53|93\r\n53|73\r\n53|21\r\n53|11\r\n53|94\r\n53|49\r\n53|59\r\n53|66\r\n53|97\r\n53|39\r\n46|24\r\n46|18\r\n46|36\r\n46|95\r\n46|27\r\n46|67\r\n46|85\r\n46|94\r\n46|71\r\n46|54\r\n46|81\r\n46|35\r\n46|29\r\n46|17\r\n46|57\r\n46|62\r\n29|36\r\n29|62\r\n29|27\r\n29|53\r\n29|17\r\n29|65\r\n29|82\r\n29|57\r\n29|85\r\n29|37\r\n29|99\r\n29|45\r\n29|12\r\n29|86\r\n29|59\r\n29|26\r\n29|35\r\n85|65\r\n85|62\r\n85|59\r\n85|77\r\n85|91\r\n85|69\r\n85|31\r\n85|57\r\n85|17\r\n85|14\r\n85|78\r\n85|72\r\n85|49\r\n85|53\r\n85|99\r\n85|86\r\n85|27\r\n85|36\r\n78|24\r\n78|21\r\n78|39\r\n78|81\r\n78|97\r\n78|69\r\n78|77\r\n78|87\r\n78|66\r\n78|31\r\n78|29\r\n78|15\r\n78|75\r\n78|93\r\n78|94\r\n78|54\r\n78|71\r\n78|46\r\n78|95\r\n17|72\r\n17|99\r\n17|76\r\n17|69\r\n17|59\r\n17|49\r\n17|26\r\n17|66\r\n17|86\r\n17|65\r\n17|13\r\n17|77\r\n17|78\r\n17|12\r\n17|27\r\n17|62\r\n17|14\r\n17|91\r\n17|53\r\n17|87\r\n37|31\r\n37|21\r\n37|11\r\n37|75\r\n37|53\r\n37|39\r\n37|95\r\n37|54\r\n37|46\r\n37|73\r\n37|66\r\n37|59\r\n37|24\r\n37|78\r\n37|58\r\n37|69\r\n37|15\r\n37|49\r\n37|16\r\n37|77\r\n37|94\r\n91|78\r\n91|86\r\n91|27\r\n91|77\r\n91|36\r\n91|59\r\n91|57\r\n91|13\r\n91|62\r\n91|14\r\n91|66\r\n91|76\r\n91|37\r\n91|21\r\n91|49\r\n91|69\r\n91|31\r\n91|26\r\n91|72\r\n91|12\r\n91|99\r\n91|65\r\n66|46\r\n66|18\r\n66|21\r\n66|82\r\n66|15\r\n66|58\r\n66|73\r\n66|95\r\n66|67\r\n66|97\r\n66|24\r\n66|39\r\n66|45\r\n66|11\r\n66|94\r\n66|71\r\n66|93\r\n66|54\r\n66|85\r\n66|16\r\n66|75\r\n66|29\r\n66|35\r\n57|69\r\n57|21\r\n57|66\r\n57|99\r\n57|72\r\n57|59\r\n57|13\r\n57|65\r\n57|12\r\n57|26\r\n57|31\r\n57|16\r\n57|75\r\n57|87\r\n57|53\r\n57|76\r\n57|11\r\n57|37\r\n57|49\r\n57|73\r\n57|86\r\n57|77\r\n57|14\r\n57|78\r\n36|14\r\n36|49\r\n36|57\r\n36|72\r\n36|87\r\n36|16\r\n36|99\r\n36|65\r\n36|59\r\n36|12\r\n36|37\r\n36|21\r\n36|11\r\n36|31\r\n36|75\r\n36|69\r\n36|86\r\n36|13\r\n36|66\r\n36|26\r\n36|53\r\n36|78\r\n36|77\r\n36|76\r\n93|72\r\n93|91\r\n93|71\r\n93|12\r\n93|17\r\n93|37\r\n93|86\r\n93|27\r\n93|29\r\n93|36\r\n93|14\r\n93|45\r\n93|57\r\n93|81\r\n93|26\r\n93|65\r\n93|82\r\n93|18\r\n93|67\r\n93|85\r\n93|35\r\n93|99\r\n93|76\r\n93|62\r\n14|75\r\n14|73\r\n14|16\r\n14|69\r\n14|37\r\n14|72\r\n14|77\r\n14|95\r\n14|15\r\n14|46\r\n14|26\r\n14|31\r\n14|99\r\n14|49\r\n14|78\r\n14|21\r\n14|66\r\n14|87\r\n14|12\r\n14|59\r\n14|53\r\n14|58\r\n14|13\r\n14|11\r\n73|95\r\n73|58\r\n73|81\r\n73|67\r\n73|46\r\n73|24\r\n73|27\r\n73|18\r\n73|91\r\n73|15\r\n73|71\r\n73|39\r\n73|62\r\n73|85\r\n73|45\r\n73|17\r\n73|82\r\n73|29\r\n73|35\r\n73|97\r\n73|36\r\n73|54\r\n73|93\r\n73|94\r\n94|86\r\n94|45\r\n94|17\r\n94|36\r\n94|57\r\n94|67\r\n94|72\r\n94|35\r\n94|91\r\n94|81\r\n94|27\r\n94|14\r\n94|71\r\n94|85\r\n94|54\r\n94|93\r\n94|82\r\n94|65\r\n94|76\r\n94|18\r\n94|62\r\n94|26\r\n94|29\r\n94|24\r\n15|62\r\n15|45\r\n15|54\r\n15|57\r\n15|94\r\n15|85\r\n15|35\r\n15|39\r\n15|67\r\n15|18\r\n15|76\r\n15|65\r\n15|71\r\n15|81\r\n15|93\r\n15|36\r\n15|82\r\n15|27\r\n15|17\r\n15|29\r\n15|24\r\n15|86\r\n15|97\r\n15|91\r\n24|86\r\n24|54\r\n24|12\r\n24|71\r\n24|82\r\n24|72\r\n24|85\r\n24|17\r\n24|76\r\n24|18\r\n24|57\r\n24|14\r\n24|93\r\n24|91\r\n24|27\r\n24|45\r\n24|81\r\n24|65\r\n24|29\r\n24|26\r\n24|62\r\n24|67\r\n24|36\r\n24|35\r\n12|69\r\n12|31\r\n12|58\r\n12|75\r\n12|49\r\n12|13\r\n12|53\r\n12|59\r\n12|11\r\n12|46\r\n12|78\r\n12|97\r\n12|21\r\n12|99\r\n12|95\r\n12|16\r\n12|94\r\n12|66\r\n12|87\r\n12|37\r\n12|15\r\n12|77\r\n12|39\r\n12|73\r\n58|54\r\n58|81\r\n58|94\r\n58|45\r\n58|36\r\n58|18\r\n58|82\r\n58|15\r\n58|17\r\n58|62\r\n58|57\r\n58|95\r\n58|93\r\n58|24\r\n58|35\r\n58|97\r\n58|71\r\n58|67\r\n58|85\r\n58|29\r\n58|65\r\n58|39\r\n58|91\r\n58|27\r\n95|81\r\n95|85\r\n95|29\r\n95|93\r\n95|71\r\n95|76\r\n95|15\r\n95|27\r\n95|91\r\n95|97\r\n95|57\r\n95|62\r\n95|65\r\n95|24\r\n95|35\r\n95|18\r\n95|94\r\n95|39\r\n95|45\r\n95|36\r\n95|82\r\n95|67\r\n95|17\r\n95|54\r\n54|17\r\n54|86\r\n54|99\r\n54|67\r\n54|26\r\n54|35\r\n54|81\r\n54|76\r\n54|18\r\n54|27\r\n54|91\r\n54|85\r\n54|36\r\n54|65\r\n54|57\r\n54|14\r\n54|71\r\n54|45\r\n54|12\r\n54|72\r\n54|93\r\n54|82\r\n54|62\r\n54|29\r\n31|67\r\n31|81\r\n31|29\r\n31|16\r\n31|21\r\n31|46\r\n31|54\r\n31|75\r\n31|24\r\n31|93\r\n31|71\r\n31|73\r\n31|95\r\n31|87\r\n31|58\r\n31|15\r\n31|39\r\n31|82\r\n31|66\r\n31|35\r\n31|97\r\n31|69\r\n31|11\r\n31|94\r\n75|91\r\n75|85\r\n75|93\r\n75|97\r\n75|24\r\n75|17\r\n75|46\r\n75|35\r\n75|29\r\n75|39\r\n75|18\r\n75|95\r\n75|54\r\n75|27\r\n75|62\r\n75|15\r\n75|73\r\n75|67\r\n75|94\r\n75|81\r\n75|45\r\n75|58\r\n75|71\r\n75|82\r\n39|14\r\n39|45\r\n39|94\r\n39|57\r\n39|27\r\n39|54\r\n39|81\r\n39|85\r\n39|86\r\n39|35\r\n39|36\r\n39|76\r\n39|91\r\n39|71\r\n39|93\r\n39|17\r\n39|97\r\n39|65\r\n39|67\r\n39|29\r\n39|62\r\n39|18\r\n39|82\r\n39|24\r\n86|11\r\n86|53\r\n86|77\r\n86|12\r\n86|26\r\n86|95\r\n86|75\r\n86|46\r\n86|58\r\n86|73\r\n86|37\r\n86|72\r\n86|21\r\n86|13\r\n86|16\r\n86|99\r\n86|87\r\n86|31\r\n86|69\r\n86|49\r\n86|66\r\n86|78\r\n86|59\r\n86|14\r\n62|65\r\n62|13\r\n62|72\r\n62|69\r\n62|59\r\n62|21\r\n62|66\r\n62|77\r\n62|12\r\n62|36\r\n62|53\r\n62|86\r\n62|76\r\n62|26\r\n62|37\r\n62|16\r\n62|11\r\n62|99\r\n62|14\r\n62|57\r\n62|87\r\n62|49\r\n62|78\r\n62|31\r\n76|12\r\n76|59\r\n76|49\r\n76|87\r\n76|14\r\n76|72\r\n76|11\r\n76|73\r\n76|66\r\n76|69\r\n76|86\r\n76|77\r\n76|13\r\n76|99\r\n76|21\r\n76|46\r\n76|31\r\n76|78\r\n76|26\r\n76|75\r\n76|58\r\n76|37\r\n76|53\r\n76|16\r\n81|36\r\n81|82\r\n81|45\r\n81|37\r\n81|85\r\n81|72\r\n81|49\r\n81|76\r\n81|26\r\n81|99\r\n81|35\r\n81|86\r\n81|14\r\n81|62\r\n81|13\r\n81|59\r\n81|12\r\n81|27\r\n81|65\r\n81|53\r\n81|91\r\n81|57\r\n81|18\r\n81|17\r\n21|45\r\n21|29\r\n21|94\r\n21|17\r\n21|71\r\n21|24\r\n21|82\r\n21|93\r\n21|67\r\n21|97\r\n21|11\r\n21|75\r\n21|85\r\n21|95\r\n21|54\r\n21|58\r\n21|46\r\n21|39\r\n21|35\r\n21|81\r\n21|73\r\n21|16\r\n21|15\r\n21|18\r\n27|57\r\n27|66\r\n27|59\r\n27|21\r\n27|87\r\n27|62\r\n27|69\r\n27|76\r\n27|65\r\n27|14\r\n27|36\r\n27|77\r\n27|11\r\n27|53\r\n27|72\r\n27|86\r\n27|13\r\n27|78\r\n27|37\r\n27|12\r\n27|31\r\n27|99\r\n27|26\r\n27|49\r\n45|36\r\n45|99\r\n45|14\r\n45|12\r\n45|77\r\n45|65\r\n45|85\r\n45|31\r\n45|69\r\n45|72\r\n45|27\r\n45|78\r\n45|17\r\n45|86\r\n45|26\r\n45|49\r\n45|57\r\n45|76\r\n45|37\r\n45|53\r\n45|59\r\n45|62\r\n45|13\r\n45|91\r\n13|58\r\n13|46\r\n13|73\r\n13|78\r\n13|66\r\n13|21\r\n13|29\r\n13|95\r\n13|31\r\n13|93\r\n13|16\r\n13|11\r\n13|94\r\n13|77\r\n13|67\r\n13|39\r\n13|71\r\n13|54\r\n13|24\r\n13|69\r\n13|97\r\n13|75\r\n13|87\r\n13|15\r\n77|46\r\n77|71\r\n77|93\r\n77|15\r\n77|73\r\n77|67\r\n77|54\r\n77|95\r\n77|11\r\n77|87\r\n77|82\r\n77|69\r\n77|81\r\n77|24\r\n77|21\r\n77|94\r\n77|29\r\n77|31\r\n77|66\r\n77|75\r\n77|97\r\n77|58\r\n77|39\r\n77|16\r\n71|45\r\n71|76\r\n71|67\r\n71|65\r\n71|14\r\n71|57\r\n71|29\r\n71|37\r\n71|35\r\n71|99\r\n71|82\r\n71|72\r\n71|53\r\n71|12\r\n71|27\r\n71|81\r\n71|86\r\n71|18\r\n71|85\r\n71|36\r\n71|17\r\n71|91\r\n71|62\r\n71|26\r\n97|81\r\n97|27\r\n97|67\r\n97|14\r\n97|94\r\n97|36\r\n97|62\r\n97|71\r\n97|57\r\n97|35\r\n97|54\r\n97|82\r\n97|45\r\n97|65\r\n97|91\r\n97|86\r\n97|24\r\n97|76\r\n97|72\r\n97|17\r\n97|85\r\n97|93\r\n97|29\r\n97|18\r\n99|87\r\n99|37\r\n99|75\r\n99|49\r\n99|95\r\n99|39\r\n99|66\r\n99|21\r\n99|53\r\n99|77\r\n99|24\r\n99|69\r\n99|16\r\n99|78\r\n99|46\r\n99|59\r\n99|97\r\n99|58\r\n99|94\r\n99|15\r\n99|13\r\n99|73\r\n99|11\r\n26|97\r\n26|59\r\n26|13\r\n26|66\r\n26|58\r\n26|78\r\n26|77\r\n26|73\r\n26|53\r\n26|15\r\n26|11\r\n26|39\r\n26|49\r\n26|37\r\n26|46\r\n26|87\r\n26|99\r\n26|12\r\n26|16\r\n26|75\r\n26|95\r\n26|31\r\n69|93\r\n69|29\r\n69|81\r\n69|94\r\n69|82\r\n69|58\r\n69|71\r\n69|21\r\n69|39\r\n69|11\r\n69|46\r\n69|16\r\n69|15\r\n69|24\r\n69|97\r\n69|73\r\n69|54\r\n69|66\r\n69|18\r\n69|87\r\n69|67\r\n59|77\r\n59|69\r\n59|66\r\n59|78\r\n59|16\r\n59|93\r\n59|46\r\n59|95\r\n59|15\r\n59|24\r\n59|13\r\n59|49\r\n59|11\r\n59|21\r\n59|75\r\n59|31\r\n59|54\r\n59|97\r\n59|39\r\n59|71\r\n82|12\r\n82|26\r\n82|76\r\n82|18\r\n82|85\r\n82|35\r\n82|59\r\n82|86\r\n82|45\r\n82|36\r\n82|17\r\n82|53\r\n82|27\r\n82|57\r\n82|78\r\n82|37\r\n82|14\r\n82|13\r\n82|65\r\n65|75\r\n65|31\r\n65|46\r\n65|26\r\n65|21\r\n65|13\r\n65|78\r\n65|77\r\n65|12\r\n65|66\r\n65|76\r\n65|53\r\n65|72\r\n65|49\r\n65|14\r\n65|99\r\n65|87\r\n65|16\r\n49|11\r\n49|94\r\n49|93\r\n49|54\r\n49|46\r\n49|78\r\n49|95\r\n49|73\r\n49|15\r\n49|58\r\n49|24\r\n49|77\r\n49|75\r\n49|87\r\n49|39\r\n49|97\r\n49|21\r\n18|31\r\n18|72\r\n18|49\r\n18|99\r\n18|45\r\n18|77\r\n18|53\r\n18|78\r\n18|26\r\n18|85\r\n18|13\r\n18|76\r\n18|59\r\n18|62\r\n18|65\r\n18|36\r\n72|75\r\n72|73\r\n72|53\r\n72|78\r\n72|13\r\n72|69\r\n72|87\r\n72|12\r\n72|15\r\n72|99\r\n72|77\r\n72|26\r\n72|46\r\n72|95\r\n72|58\r\n67|14\r\n67|17\r\n67|45\r\n67|65\r\n67|49\r\n67|36\r\n67|62\r\n67|18\r\n67|59\r\n67|85\r\n67|91\r\n67|26\r\n67|57\r\n67|86\r\n11|73\r\n11|16\r\n11|46\r\n11|95\r\n11|54\r\n11|85\r\n11|58\r\n11|71\r\n11|29\r\n11|18\r\n11|45\r\n11|93\r\n11|91\r\n16|93\r\n16|29\r\n16|97\r\n16|73\r\n16|54\r\n16|27\r\n16|58\r\n16|24\r\n16|75\r\n16|81\r\n16|71\r\n16|35\r\n35|17\r\n35|14\r\n35|18\r\n35|27\r\n35|26\r\n35|53\r\n35|85\r\n35|77\r\n35|13\r\n35|65\r\n35|76\r\n87|66\r\n87|15\r\n87|39\r\n87|45\r\n87|82\r\n87|16\r\n87|54\r\n87|29\r\n87|75\r\n87|93\r\n53|95\r\n53|77\r\n53|24\r\n53|69\r\n53|87\r\n53|75\r\n53|46\r\n53|15\r\n53|31\r\n46|15\r\n46|45\r\n46|93\r\n46|97\r\n46|58\r\n46|39\r\n46|91\r\n46|82\r\n29|72\r\n29|67\r\n29|18\r\n29|14\r\n29|76\r\n29|81\r\n29|91\r\n85|26\r\n85|87\r\n85|37\r\n85|13\r\n85|12\r\n85|76\r\n78|16\r\n78|67\r\n78|11\r\n78|73\r\n78|58\r\n17|37\r\n17|36\r\n17|31\r\n17|57\r\n37|13\r\n37|97\r\n37|87\r\n91|53\r\n91|87\r\n66|81\r\n\r\n75,94,71,16,31,95,11,73,97,77,81\r\n17,91,62,86,14,26,12,99,37,59,49,13,77\r\n62,36,12,37,49,78,77,31,87,21,11\r\n59,13,31,16,75,58,95,15,39,24,54\r\n95,15,39,97,94,24,54,93,67,81,82,35,18,45,85,17,91,27,62,36,65\r\n36,53,67,14,62,26,99,35,81,65,29,82,76,17,57,27,37,18,72,86,91\r\n46,15,39,71,81,82,35,45,85,91,36\r\n16,91,15,29,46,17,67\r\n49,77,31,46,53,58,73,95,75,78,99,21,15,13,59\r\n73,46,95,15,97,54,71,81,45,85,62\r\n14,72,26,12,99,59,49,78,77,31,69,87,21,11,16,75,95\r\n54,93,71,29,67,81,82,35,18,85,17,91,62,36,57,65,76,86,14,72,26\r\n93,85,67,57,36,72,35,65,45,18,76,24,86,82,94,29,54,14,17,62,71\r\n13,78,77,31,69,87,66,21,11,16,73,46,58,15,39,97,94,24,54,71,29\r\n53,75,31,49,73,14,77,11,21,26,76,72,86,87,46,13,16,78,69,37,12,99,66\r\n87,66,11,16,75,46,58,95,15,97,94,24,54,93,29,67,82,35,18\r\n99,53,31,16,37,58,12,66,46,49,87,75,59,26,39,73,13\r\n17,91,27,62,36,57,76,86,14,72,26,12,99,37,53,59,13,78,77,31,69\r\n13,78,77,31,21,11,16,75,73,46,58,15,39,97,24,54,93,71,29\r\n94,54,93,29,81,45,85,62,57,65,76,14,72\r\n93,81,82,45,17,27,62,36,57,76,86,14,72,26,99\r\n24,93,71,35,45,17,62,36,76\r\n14,66,87,73,75,46,26,99,21,72,77,12,53,49,59,37,69,16,11,86,78\r\n65,76,86,72,99,53,13,77,69,21,11,75,73\r\n59,45,62,27,36,72,78,18,85,65,12,99,76,77,14\r\n65,14,26,37,53,13,87,75,73\r\n53,59,13,78,77,31,87,66,21,11,75,73,46,58,95,15,97,94,54\r\n21,75,58,24,71,35,85\r\n37,76,18,26,57,14,12,45,27,53,99,17,86,35,62,29,67,85,91\r\n76,45,26,57,77,85,36,17,13,59,53,27,62\r\n87,11,16,73,46,15,97,54,82,35,18\r\n13,78,77,31,69,87,66,21,16,75,73,46,15,39,97,94,24,71,29\r\n29,93,71,58,11,16,21,94,54,75,97,81,67,15,87,18,35,73,39,82,24,66,95\r\n36,17,29,71,27,62,45,81,18,91,54\r\n31,69,21,16,73,24,93\r\n97,66,54,71,15,29,24,45,75,67,94\r\n75,73,58,94,18\r\n75,58,15,97,54,93,71,82,35,18,27\r\n85,26,17,93,86,81,72,45,12,14,76,36,65,27,91,35,67,71,57,18,62,82,29\r\n24,54,93,71,29,67,81,82,18,45,85,17,91,27,62,36,57,65,76,86,14,72,26\r\n54,24,97,85,93,17,29,45,58,35,75,27,73,46,39,71,15,91,67,82,81,94,95\r\n12,13,69,77,11,72,86,53,78,62,26,66,14,49,59,57,99\r\n15,39,97,94,24,54,93,71,29,67,81,35,18,45,85,17,91,27,62,36,57,65,76\r\n16,75,73,46,58,39,97,94,24,54,93,71,29,67,81,82,35,18,45,17,91\r\n81,82,35,18,45,85,17,91,27,36,57,65,76,26,99,37,53\r\n37,11,87,14,99,59,69,57,77,76,13,86,31,72,49,78,12,16,65,66,26,53,21\r\n58,95,15,39,94,24,54,93,71,29,67,81,82,35,18,45,85,17,91,27,62,36,57\r\n81,16,73,39,21,15,46\r\n69,87,66,11,75,95,15,94,54,93,81,82,35\r\n12,36,53,76,14,59,77,72,69,27,31,65,91,85,13,86,99\r\n14,72,26,12,99,37,53,59,49,13,31,69,87,66,21,11,16,75,73,58,95\r\n24,45,39,97,85,15,75,17,73,95,46,71,11,93,94,29,82,35,16\r\n86,14,72,26,12,99,37,53,59,49,13,78,31,69,87,66,21,11,75,46,58\r\n78,77,66,11,16,75,73,46,58,95,15,97,24,54,93,29,67\r\n12,37,53,13,77,69,87,21,11,46,58,15,97\r\n17,91,27,62,36,57,65,76,86,14,26,12,99,37,53,59,49,78,31,69,87\r\n31,66,58,15,24,67,82\r\n45,85,62,14,72,12,99,37,53,59,49,13,78\r\n69,78,24,73,31,58,67,11,94,71,54,75,93,66,21,87,97,16,15,39,29,95,77\r\n78,65,14,27,66,21,76,31,57,26,13,37,99,53,12,36,72,59,49,62,86\r\n39,97,94,24,54,93,71,29,81,82,35,18,45,85,17,91,27,62,36,57,65,76,86\r\n93,29,18,82,73,24,81,11,16\r\n12,37,53,49,13,78,31,66,21,73,58,95,97\r\n97,35,15,11,58,16,21,75,39,29,54,45,18,46,85,94,73\r\n73,95,15,97,24,54,93,29,82,35,45,17,91,27,62\r\n15,95,53,99,37,73,87,59,66,12,97\r\n18,45,85,27,36,65,76,86,14,72,26,99,37,59,77\r\n97,87,49,75,11,13,54,15,73,78,31,53,21\r\n53,77,21,46,16,13,87,58,26,37,31,99,49,78,12,95,11,72,73,59,66,15,69\r\n53,66,75,46,97,24,54\r\n73,16,31,24,21,97,95,87,13,58,54,11,75,39,69,94,77,49,66,15,46\r\n66,15,93,82,35,18,45\r\n78,26,73,37,59,49,99,31,39,46,58,15,21,69,12,87,11,16,77\r\n91,76,62,67,35,36,27,17,81,86,57,24,29,97,71,45,39,54,94,18,65\r\n15,59,72,53,77,99,69,21,16\r\n35,54,94,27,82,46,67,24,15\r\n82,91,29,14,76,24,36,35,26,57,17,93,54,67,85,65,18,27,45,72,71,81,62\r\n71,87,15,29,95,39,16,75,24,11,13,73,31,46,21,58,69,77,94,66,54,78,93\r\n46,78,37,49,53,26,69,73,99,31,13,11,77,58,12,87,16\r\n76,86,14,72,26,12,99,59,49,78,77,31,69,87,66,21,11,16,75,73,46\r\n97,24,93,29,67,35,18,45,85,17,91,62,36,57,65,86,14\r\n39,97,54,71,29,67,82,35,18,45,85,17,57\r\n72,86,76,31,87,46,59,66,11,53,16,21,73,37,26,69,78\r\n71,45,91,27,57,99,37\r\n59,49,31,21,73,58,95,97,93\r\n21,11,16,46,97,94,71,67,35,45,85\r\n29,24,75,35,11,45,95,66,97,21,73,16,82,58,67\r\n17,36,31,91,14,57,59,53,87,65,77,49,99,62,26\r\n67,94,45,58,11,17,81,39,71\r\n75,53,97,49,69,39,21,58,37,12,87,15,77\r\n77,93,58,75,66,73,46,15,81\r\n37,53,59,49,13,77,31,69,87,66,21,11,16,75,73,46,58,95,15,39,97,94,24\r\n87,66,21,11,16,75,73,46,58,15,39,97,94,24,54,93,71,29,67,81,82,35,18\r\n62,26,91,45,35,82,67\r\n45,82,35,29,58,73,95,93,16,91,15,85,94,75,67,18,46,71,17\r\n54,91,94,71,18,45,17,82,67,24,27,81,36,14,35,57,93,76,62,29,85,65,86\r\n29,67,35,18,45,91,76,86,12,37,53\r\n71,24,15,16,18,46,97,29,39,54,35,21,67,45,82,75,58,94,93,81,11,73,85\r\n45,24,82,27,17,67,71,62,18,26,35,72,54,81,76,57,29\r\n67,81,35,85,17,27,62,57,65,76,12\r\n15,91,57,97,24,27,81,85,94,65,95,17,82\r\n67,45,35,46,15,16,82,71,85,17,18,94,58,54,91\r\n46,58,95,15,94,24,54,71,29,35,18,45,17,91,27,62,36\r\n31,65,59,69,26,76,12,77,17,91,86,57,37,85,13\r\n65,86,35,78,27,85,59,99,76,91,14\r\n36,57,76,72,53,49,13,31,69,87,66,21,16\r\n75,93,91,95,46,94,16,24,54,67,35,39,58,85,45,73,18,82,97,29,71,81,17\r\n26,12,59,13,69,16,46\r\n24,93,59,94,49,31,66\r\n94,24,54,93,71,29,67,81,35,18,45,85,17,91,27,62,36,57,65,76,86,14,72\r\n14,72,37,59,13,78,77,69,11,16,46,58,95\r\n86,69,66,78,21,49,87,27,76,37,36,72,65,57,26\r\n72,26,16,73,46,95,15\r\n97,91,54,17,35,82,62,18,58,94,57,39,95,29,93\r\n45,62,36,57,37\r\n54,78,69,75,58,46,21,24,53\r\n53,62,57,13,17,14,65,49,12,36,86,18,26,59,76,91,77,45,78\r\n37,53,59,78,77,31,87,16,75,73,15,39,97,94,24\r\n94,24,54,93,67,17,27,36,14\r\n73,46,58,97,54,29,35\r\n91,62,65,72,12,37,69\r\n58,69,59,16,78,77,12,73,37,97,13,87,39,21,99,11,75\r\n62,36,65,86,12,99,37,53,31,87,21\r\n15,97,24,54,93,71,29,81,82,35,18,45,85,17,27,36,57,65,76\r\n76,86,14,26,12,99,37,59,49,78,77,31,69,66,21,11,16,73,46\r\n49,13,78,69,66,11,16,46,58,97,94,93,71\r\n24,54,73,91,58,15,97,29,17,62,95,93,82,67,81,85,46\r\n73,46,58,95,15,39,24,54,29,67,81,35,18,45,17,27,62\r\n91,27,36,12,37,49,78,31,66\r\n95,66,15,75,78,99,58,26,39,77,16,46,11\r\n67,82,35,45,85,17,62,65,76,86,14,72,37,53,59\r\n35,18,45,85,17,91,27,36,57,76,86,72,26,12,99,37,53,49,13\r\n82,35,18,45,85,17,91,27,62,36,57,65,76,86,14,72,12,99,37,53,59,49,13\r\n53,59,49,13,77,31,87,66,11,16,75,46,58,95,39,97,94,24,54\r\n27,62,36,57,76,86,14,72,26,12,37,49,13,78,77,31,87,66,21\r\n72,26,49,13,87,75,73\r\n16,75,73,39,54,71,29,35,18,45,17\r\n97,94,71,29,67,35,27,62,14\r\n57,65,76,86,14,26,12,99,37,53,49,13,77,69,87,16,75\r\n78,77,31,69,87,66,11,16,75,73,46,58,95,15,94,24,54,93,71,29,67\r\n57,86,72,26,12,49,77,69,87,66,75\r\n78,77,31,69,87,66,11,75,73,46,58,15,97,94,24,71,29\r\n77,87,66,21,75,95,97,24,81\r\n59,13,78,77,31,69,87,66,75,95,39,97,24,54,93\r\n77,31,69,87,66,21,11,16,75,73,46,58,95,15,39,94,24,54,93,71,29,67,81\r\n14,72,26,99,13,78,77,31,87,16,75,46,95\r\n27,62,36,57,65,76,86,14,72,26,12,99,37,59,49,13,78,77,31,69,87,66,21\r\n69,87,66,21,11,16,75,73,46,58,39,94,24,93,71,29,67,81,35\r\n76,37,53,13,31,66,21,11,46\r\n59,76,62,26,67,27,36\r\n65,69,37,59,86,26,27,78,13,36,31,21,77,99,62,14,72\r\n66,37,58,13,78,95,12,69,39,53,46,75,26,31,99,73,16\r\n81,67,14,18,82,85,91,27,26,72,36,65,24,17,29,57,62,86,93,76,71\r\n14,72,12,99,37,53,59,49,78,77,31,69,87,66,21,11,75,73,46,58,95\r\n49,13,78,77,31,69,66,21,11,16,75,73,46,58,95,15,39,97,94,24,54,93,71\r\n13,78,69,66,73,95,94,24,54,93,71\r\n14,53,57,86,37,49,17,62,85,26,72,27,91\r\n39,97,94,24,54,93,71,29,67,81,82,35,18,45,85,17,91,27,62,36,57,65,76\r\n97,16,71,29,94,35,69,66,46,39,24,67,95\r\n82,35,18,45,85,17,91,27,62,36,57,65,76,86,14,72,12,99,37,53,59,49,13\r\n65,14,26,99,53,13,78,77,11,16,73\r\n82,46,71,94,81,93,67,62,36,54,17,29,91\r\n29,67,81,82,35,18,45,85,17,91,27,62,36,57,65,76,86,14,72,26,12,37,53\r\n21,75,73,93,54,94,97,87,66\r\n11,21,35,46,16,87,67,66,95,18,97,81,82\r\n81,82,35,18,45,17,91,27,62,36,57,65,76,14,72,12,99,37,53,59,49\r\n26,37,71,76,35,62,91,57,67,65,86,18,99\r\n31,16,75,73,58,93,67\r\n46,75,21,15,66,87,39,73,94,59,99,13,31,58,16,77,49\r\n85,81,17,76,71,86,57,72,27,62,67,26,36,18,14,91,12\r\n69,16,54,71,95\r\n94,82,27,71,85,46,45,15,93,18,54,39,97,91,95,81,29,24,62\r\n26,37,53,59,49,13,78,87,66,21,16,75,73,58,95,15,39\r\n66,16,58,95,39,97,54,71,45\r\n37,53,49,77,31,69,87,66,21,46,58,94,24\r\n35,75,73,54,15,66,69,67,39\r\n21,75,73,58,95,15,39,97,94,54,93,71,67,81,35,45,85\r\n69,87,21,16,93,71,29,67,81,82,35\r\n18,85,91,62,36,57,86,14,26,12,53,13,77\r\n18,36,12,77,78,86,59\r\n13,77,69,75,73,46,95,94,24,54,71\r\n29,67,18,85,17,91,27,62,65,76,86,26,53\r\n87,65,11,57,53,21,13,49,12,86,76\r\n91,57,29,27,12,81,67,93,26,65,36,76,18,17,14,85,62,35,71,54,72\r\n54,93,81,45,85,17,91,27,62,36,76,14,72,26,12\r\n66,21,39,93,71,67,35\r\n59,27,26,14,76,72,37,35,62,65,12,78,13\r\n94,24,66,93,39,59,16,97,11,15,31\r\n26,12,53,49,13,78,77,31,66,21,11,95,39\r\n17,86,14,72,12,49,13,78,77,69,87\r\n67,35,93,87,15,58,97,16,21,69,81,46,11,29,75,94,71,54,82\r\n78,77,86,49,13,12,87,72,53,16,69,21,99,36,76,59,14,31,57,65,11\r\n21,16,75,73,46,58,95,39,97,54,93,71,82,35,18,45,85\r\n45,57,37,14,59,17,36,78,35,12,13,62,18,91,76,53,86,72,49,26,85\r\n54,93,85,27,57,76,72,26,12\r\n95,15,97,94,24,71,29,35,18,91,27\r\n37,36,86,27,62\r\n31,69,87,66,21,11,75,73,46,58,95,94,24,71,67,81,82\r\n45,91,82,17,36,58,71,81,39,18,54,15,27\r\n59,27,36,87,99,12,49,31,77,72,76,78,53,62,69,17,26,91,57";
    }
}
