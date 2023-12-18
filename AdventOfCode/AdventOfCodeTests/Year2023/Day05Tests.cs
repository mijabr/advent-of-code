using AdventOfCode.Year2023;

namespace AdventOfCodeTests.Year2023
{
    public class Day05Tests
    {
        [Test]
        public void SeedMapper_CanReadInput()
        {
            var seedMapper = SeedMapper.Create(exampleInput);

            seedMapper.SourceSeeds.Should().BeEquivalentTo(new int[] { 79, 14, 55, 13 });
            seedMapper.Maps["seed"].Should().NotBeNull();
            seedMapper.Maps["soil"].Should().NotBeNull();
            seedMapper.Maps["seed"].RangeMapSegements[0].Should().BeEquivalentTo(new RangeMapSegement(50, 98, 2));
            seedMapper.Maps["fertilizer"].RangeMapSegements[2].Should().BeEquivalentTo(new RangeMapSegement(42, 0, 7));
        }

        [Test]
        public void SeedMapper_CanMapValues()
        {
            var seedMapper = SeedMapper.Create(exampleInput);

            seedMapper.Maps["seed"].Convert(79).Should().Be(81);
            seedMapper.Maps["seed"].Convert(14).Should().Be(14);
            seedMapper.Maps["seed"].Convert(55).Should().Be(57);
            seedMapper.Maps["seed"].Convert(13).Should().Be(13);
            seedMapper.Maps["fertilizer"].Convert(81).Should().Be(81);
            seedMapper.Maps["water"].Convert(81).Should().Be(74);
            seedMapper.Maps["light"].Convert(74).Should().Be(78);
            seedMapper.Maps["temperature"].Convert(78).Should().Be(78);
            seedMapper.Maps["humidity"].Convert(78).Should().Be(82);
        }

        [Test]
        public void SeedMapper_CanSolveExample1()
        {
            var seedMapper = SeedMapper.Create(exampleInput);

            seedMapper.Lowest("location").Should().Be(35);
        }

        [Test]
        public void SeedMapper_CanSolvePart1()
        {
            var seedMapper = SeedMapper.Create(input);

            seedMapper.Lowest("location").Should().Be(173706076L);
        }

        [Test]
        public void SeedMapper_CanReadInputPart2()
        {
            var seedMapper = SeedMapper.Create(exampleInput, rangedSeedInput: true);

            seedMapper.SourceSeeds.Should().BeEquivalentTo(new SeedRange[] { new SeedRange(79, 14), new SeedRange(55, 13) });
        }

        [Test]
        public void SeedMapper_CanSolveExample1Part2()
        {
            var seedMapper = SeedMapper.Create(exampleInput, rangedSeedInput: true);

            seedMapper.Lowest("location").Should().Be(46);
        }

        [Test]
        public void SeedMapper_CanSolvePart2()
        {
            var seedMapper = SeedMapper.Create(input, rangedSeedInput: true);

            seedMapper.Lowest("location").Should().Be(11611182);
        }

        const string exampleInput = "seeds: 79 14 55 13\r\n\r\nseed-to-soil map:\r\n50 98 2\r\n52 50 48\r\n\r\nsoil-to-fertilizer map:\r\n0 15 37\r\n37 52 2\r\n39 0 15\r\n\r\nfertilizer-to-water map:\r\n49 53 8\r\n0 11 42\r\n42 0 7\r\n57 7 4\r\n\r\nwater-to-light map:\r\n88 18 7\r\n18 25 70\r\n\r\nlight-to-temperature map:\r\n45 77 23\r\n81 45 19\r\n68 64 13\r\n\r\ntemperature-to-humidity map:\r\n0 69 1\r\n1 0 69\r\n\r\nhumidity-to-location map:\r\n60 56 37\r\n56 93 4";
        const string input = "seeds: 858905075 56936593 947763189 267019426 206349064 252409474 660226451 92561087 752930744 24162055 75704321 63600948 3866217991 323477533 3356941271 54368890 1755537789 475537300 1327269841 427659734\r\n\r\nseed-to-soil map:\r\n155461856 2688731658 31130392\r\n3624223750 2439220990 158522039\r\n3782745789 828496007 83184667\r\n1329508120 2383184162 2195641\r\n1221066973 4005538912 108441147\r\n3908459768 630332333 84015758\r\n3174818941 2385379803 53841187\r\n1929319035 442552891 126280229\r\n2999332985 2077874265 61338040\r\n4047976345 4113980059 50652162\r\n3509978464 2319317936 63866226\r\n2676242573 568833120 11879128\r\n4146174193 3589840038 35847908\r\n3865930456 2986517951 42529312\r\n1737209176 3963710397 41828515\r\n2545388005 3458985470 130854568\r\n388171875 2946497456 40020495\r\n3396281190 4164632221 79956015\r\n186592248 1068698177 201579627\r\n3060671025 714348091 114147916\r\n2841183920 2139212305 158149065\r\n2055599264 3290256747 27665085\r\n2770917385 3029047263 24920289\r\n4203978667 2597743029 90988629\r\n2795837674 911680674 45346246\r\n2083264349 2813972956 124101205\r\n3573844690 4244588236 50379060\r\n3228660128 274931829 167621062\r\n1331703761 1270277804 23145153\r\n123824510 3053967552 31637346\r\n1354848914 63482157 211449672\r\n1566298586 3085604898 170910590\r\n63482157 3398643117 60342353\r\n3476237205 3256515488 33741259\r\n1212643678 2938074161 8423295\r\n4182022101 2297361370 21956566\r\n3992475526 2758472137 55500819\r\n428192370 1293422957 784451308\r\n1817647778 957026920 111671257\r\n2690196100 3317921832 80721285\r\n1779037691 2719862050 38610087\r\n4098628507 582786647 47545686\r\n2207365554 3625687946 338022451\r\n2688121701 580712248 2074399\r\n\r\nsoil-to-fertilizer map:\r\n2233530624 2071120505 422489795\r\n3959649465 4044567411 67616189\r\n457224864 3135270167 41569374\r\n3394360972 4112183600 182783696\r\n813178253 653702020 183734547\r\n498794238 2963315974 171954193\r\n3577144668 3394360972 216442995\r\n996912800 2493610300 327275852\r\n3309722439 3282071367 51304963\r\n670748431 2820886152 142429822\r\n1324188652 3273822993 8248374\r\n3793587663 4006086952 11248169\r\n2190085090 3176839541 43445534\r\n2656020419 0 653702020\r\n4267735006 4017335121 27232290\r\n1396875915 3333376330 27651072\r\n4027265654 3610803967 240469352\r\n1424526987 1241123513 765558103\r\n403686946 3220285075 53537918\r\n3804835832 3851273319 154813633\r\n1332437026 2006681616 64438889\r\n0 837436567 403686946\r\n\r\nfertilizer-to-water map:\r\n490664090 841327865 158559818\r\n3248785910 3009217852 86780947\r\n3361383178 811709798 29618067\r\n1492567300 999887683 10142868\r\n708758546 1053715632 8318621\r\n2922655819 2337575757 139997093\r\n412870134 1010030551 43685081\r\n825309561 1895146974 205741813\r\n3832608203 4026085284 5525526\r\n2833741007 722794986 88914812\r\n1502710168 0 86876502\r\n1091543314 2480502815 191523114\r\n2191676162 1359275248 59328417\r\n3724763033 3918240114 107845170\r\n4132175069 4031610810 162792227\r\n1589586670 3262683858 70888723\r\n3932786977 4194403037 100564259\r\n649223908 2280749089 56826668\r\n717077167 268230878 108232394\r\n4033351236 3819416281 98823833\r\n2417689638 1418603665 416051369\r\n3062652912 3333572581 186132998\r\n1438604483 2100888787 28445966\r\n398871700 1190738587 13998434\r\n456555215 2975108977 34108875\r\n2062848712 2151921639 128827450\r\n1283066428 112692823 155538055\r\n0 475753543 244333473\r\n3838133729 3724763033 94653248\r\n244333473 1204737021 154538227\r\n1963558441 376463272 99290271\r\n3335566857 86876502 25816321\r\n3497674085 1062034253 22031494\r\n706050576 720087016 2707970\r\n1467050449 2129334753 22586886\r\n1660475393 2672025929 303083048\r\n3391001245 1084065747 106672840\r\n1031051374 1834655034 60491940\r\n1489637335 2477572850 2929965\r\n2251004579 3095998799 166685059\r\n\r\nwater-to-light map:\r\n2001282667 520918173 10302354\r\n2377955968 3484205484 30954740\r\n3394017453 2582587136 46684978\r\n99573517 443623963 59355616\r\n2759073879 2842283022 106219470\r\n3153456782 2203695607 115107673\r\n1088011149 228872916 37401521\r\n823056142 1852553918 234443509\r\n1892663777 1743935028 108618890\r\n2223186841 3648924866 154769127\r\n3440702431 3849149039 360654480\r\n1125412670 266274437 146838028\r\n2524006636 2432683670 149903466\r\n86866324 508210980 12707193\r\n3289576295 3621907778 27017088\r\n659725308 531220527 163330834\r\n336816212 1738401718 5533310\r\n1057499651 413112465 30511498\r\n1495475061 998625681 113056371\r\n1277482099 1111682052 217992962\r\n4022707650 2629272114 213010908\r\n1611665062 1454269373 134219470\r\n1272250698 502979579 5231401\r\n3801356911 2996165168 221350739\r\n2463542360 3803693993 45455046\r\n3367828633 3458016664 26188820\r\n3105794106 2948502492 47662676\r\n0 1329675014 86866324\r\n342349522 694551361 126187241\r\n158929133 820738602 177887079\r\n1608531432 1735268088 3133630\r\n2673910102 4209803519 85163777\r\n3316593383 2152460357 51235250\r\n3268564455 2116439287 21011840\r\n2508997406 2137451127 15009230\r\n2011585021 153460510 75412406\r\n1745884532 1588488843 146779245\r\n621997273 1416541338 37728035\r\n2865293349 3217515907 240500757\r\n2408910708 2318803280 54631652\r\n468536763 0 153460510\r\n4235718558 2373434932 59248738\r\n2116439287 3515160224 106747554\r\n\r\nlight-to-temperature map:\r\n1588027222 1909294051 23480302\r\n2215874455 2960213648 162391531\r\n2129487527 3462600798 86386928\r\n3484568571 1932774353 37497788\r\n1911434001 1113198957 54894781\r\n880849827 535842660 44062779\r\n1450966888 2803663201 137060334\r\n0 175732913 3492989\r\n820881151 879323733 45588873\r\n2593908227 3122605179 276522050\r\n4086321665 3399127229 59629850\r\n1267064668 2940723535 19490113\r\n872717966 579905439 8131861\r\n17372207 0 175732913\r\n325280839 781495589 97828144\r\n485661210 200622719 335219941\r\n866470024 712695420 6247942\r\n1113198957 1970272141 153865711\r\n3384296082 2124137852 23097298\r\n3492989 186743501 13879218\r\n1966328782 1746135306 163158745\r\n3522066359 3730711990 564255306\r\n1611507524 2661100955 108644269\r\n193105120 588037300 124658120\r\n423108983 718943362 62552227\r\n2870430277 2147235150 513865805\r\n2559990250 2769745224 33917977\r\n4145951515 1168093738 149015781\r\n1720151793 1558696817 187438489\r\n3407393380 1317109519 77175191\r\n1286554781 1394284710 164412107\r\n317763240 179225902 7517599\r\n2378265986 3548987726 181724264\r\n1907590282 3458757079 3843719\r\n\r\ntemperature-to-humidity map:\r\n2368894659 1388350150 55368176\r\n3669222180 3739392779 16773160\r\n4199646729 3863166637 79873794\r\n399562411 1508754364 89530529\r\n355021451 346145384 44540960\r\n3348191019 2804337123 32367820\r\n4153047357 3630809755 46599372\r\n801745354 3027789847 194064703\r\n295043332 1932435496 59978119\r\n2173824398 0 195070261\r\n3586766138 3780710595 82456042\r\n2063962300 390686344 109862098\r\n2424813637 2262322190 16002572\r\n694625758 2155376830 106945360\r\n4279520523 3615362982 15446773\r\n489092940 1655816946 66193390\r\n0 3221854550 178998524\r\n1882939638 1912164198 20271298\r\n178998524 1187862900 104517087\r\n288525818 1292379987 6517514\r\n995810057 1598284893 57532053\r\n3220600544 1992413615 127590475\r\n1857243139 195070261 25696499\r\n2424262835 1443718326 550802\r\n3143673104 1375907946 12442204\r\n3776575836 3943040431 220205828\r\n1053342110 693558780 494304120\r\n2630970071 2286623883 512703033\r\n638901084 2284929071 1694812\r\n801571118 2836704943 174236\r\n640595896 2836879179 54029862\r\n4128502701 3756165939 24544656\r\n1684527036 520842677 172716103\r\n1547646230 2890909041 136880806\r\n3524782486 3677409127 61983652\r\n3685995340 3524782486 90580496\r\n3380558839 500548442 20294235\r\n2440816209 1722010336 190153862\r\n283515611 2799326916 5010207\r\n1903210936 2120004090 35372740\r\n561890639 1298897501 77010445\r\n555286330 2278324762 6604309\r\n1938583676 220766760 125378624\r\n3996781664 4163246259 131721037\r\n3156115308 1444269128 64485236\r\n\r\nhumidity-to-location map:\r\n2420477851 2725678119 154870744\r\n341010579 1968896618 161603351\r\n2771047693 3040747240 63786420\r\n1473264654 231223255 158065928\r\n300743457 665216997 40267122\r\n4266394999 3974648226 28572297\r\n44642725 3145344681 187170981\r\n3913829571 3489505645 352565428\r\n2132898063 571123277 94093720\r\n2945529238 1729589230 52970089\r\n3205711977 3366573953 87052626\r\n3077771609 1429791513 87129347\r\n3840363983 3901182638 31190715\r\n3674520209 3842071073 59111565\r\n3733631774 4003220523 106732209\r\n0 2326199067 44642725\r\n1631330582 389289183 181834094\r\n2226991783 2370841792 193486068\r\n2911470947 3332515662 34058291\r\n1999501975 1516920860 133396088\r\n1813164676 1782559319 186337299\r\n502613930 2880548863 91268626\r\n1242041399 0 231223255\r\n3586449755 4206896842 88070454\r\n2834834113 1353642962 76148551\r\n3164900956 3104533660 40811021\r\n3489505645 4109952732 96944110\r\n2910982664 2564327860 488283\r\n3292764603 2564816143 160861976\r\n231813706 2971817489 68929751\r\n2575348595 2130499969 195699098\r\n593882556 705484119 648158843\r\n3871554698 3932373353 42274873\r\n2998499327 1650316948 79272282";
    }
}
