namespace AdventOfCodeTests.Year2022
{
    public class Day25Tests
    {
        [Test]
        public void ToInteger_ShouldReturnInteger_GivenSnafu()
        {
            var fullOfHotAir = new FullOfHotAir();

            var value = fullOfHotAir.ToInteger("1=-0-2");

            value.Should().Be(1747);
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger1()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(1);

            snafu.Should().Be("1");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger3()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(3);

            snafu.Should().Be("1=");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger4()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(4);

            snafu.Should().Be("1-");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger5()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(5);

            snafu.Should().Be("10");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger6()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(6);

            snafu.Should().Be("11");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger11()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(11);

            snafu.Should().Be("21");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger12()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(12);

            snafu.Should().Be("22");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger13()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(13);

            snafu.Should().Be("1==");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger32()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(32);

            snafu.Should().Be("112");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger201()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(201);

            snafu.Should().Be("2=01");
        }

        [Test]
        public void ToSnafu_ShouldReturnSnafu_GivenInteger1747()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafu = fullOfHotAir.ToSnafu(1747);

            snafu.Should().Be("1=-0-2");
        }

        [Test]
        public void AddUpSnafus_ShouldReturnSnafuSum_GivenSnafuList_Example1()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafuTotal = fullOfHotAir.AddUpSnafus(_exampleInput);

            snafuTotal.Should().Be("2=-1=0");
        }

        [Test]
        public void AddUpSnafus_ShouldReturnSnafuSum_GivenSnafuList_PuzzleInput()
        {
            var fullOfHotAir = new FullOfHotAir();

            var snafuTotal = fullOfHotAir.AddUpSnafus(_puzzleInput);

            snafuTotal.Should().Be("2=-0=1-0012-=-2=0=01");
        }

        private const string _exampleInput = "1=-0-2\r\n12111\r\n2=0=\r\n21\r\n2=01\r\n111\r\n20012\r\n112\r\n1=-1=\r\n1-12\r\n12\r\n1=\r\n122";

        private const string _puzzleInput = "10=-=110-0-2-\r\n120121-1=222\r\n122-0=\r\n2-212==00---2021-\r\n1--12202--2201\r\n12010-0=0111-1\r\n12=1=01=2112---111\r\n11==-2===1=022=-10\r\n1-=0\r\n21=02\r\n1-0---1-\r\n102==--2=2==2===2-\r\n2=1-0-=0=022220\r\n11=22\r\n202112100=\r\n1-20=\r\n2=-0=20-220=2=0-11\r\n1=12-001000=\r\n112\r\n2-1==-0---\r\n111122-21100=2\r\n12====-2-0-2\r\n1-12=-0==-\r\n21-2\r\n1-----1=-01\r\n1-1=-0=0-02=020\r\n2-=1\r\n1=012112\r\n1020-220201-1=1=021\r\n2-=11---1=-\r\n1=02\r\n121-1000=-=1=\r\n200-001011000=\r\n2=2-0-2\r\n111-==-0=-01-0\r\n2122-20-2010\r\n1-1-0021\r\n11-\r\n1-22=200-==10\r\n2==-=0\r\n21-20==0==02--=\r\n1-1-11-10=2012==\r\n1==20=--2=02=0-0\r\n10=0=-=0=21-1\r\n22\r\n12021=1212\r\n1-=0=101=1=11=120\r\n2-10--2\r\n10-\r\n1==1=21=02-021\r\n21=1\r\n12=\r\n1-\r\n2=0221=-=22\r\n2=====\r\n101=02110=2-\r\n1=-=\r\n10220=0-10-22-221\r\n20=221==\r\n1-2111-=0\r\n2==02212-1-=---2=\r\n1=20\r\n1==-21=2221=\r\n11=02=0-22--=1--\r\n1=2--=-2\r\n10-00=2=-220202=-\r\n1=2121-=\r\n1-202--1\r\n21-=-0=20=-=-2--1\r\n211-0012--1\r\n1-=\r\n1=--1==-=1122=2200\r\n1=20===1-=112\r\n102=210-0\r\n12\r\n11112-0=0=12\r\n2=-1=--=-20\r\n2-2=-0===-=1=1\r\n2=1=02-00--01-=-0-1\r\n1--=-21\r\n1===--===2\r\n120=2=12-=10=20111\r\n20200--=01=020\r\n1122101=10-212-=0\r\n1=1==-02=00=0-=201-2\r\n1==\r\n10000=\r\n122-2=1122=2\r\n2022==0-2==-\r\n12-22-2-\r\n201==1110-\r\n1=221--=1--0-0\r\n11=22--22200\r\n1-122=0-1-1-=-=-1\r\n2==20==-2-120-010\r\n111=1-0=1121--02\r\n10==0--21101-=11\r\n2=-1=1---\r\n102\r\n1-=0=1==-22-22\r\n2-==2=011-=\r\n1=01-\r\n1=11102112-0==0-=\r\n112222-1=\r\n11-22-0202--0\r\n1=110--=-=-=\r\n2-2--0-0\r\n1==0-==100011-=-\r\n210021-=0001---0\r\n2-=-1-==2=-\r\n1=-01-2=0-01020\r\n1-110=\r\n2110110021-202=";
    }
}
