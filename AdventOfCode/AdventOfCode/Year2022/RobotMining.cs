using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class RobotMining
    {
        public RobotMining(string input)
        {
            Blueprints = input.Split("\r\n").Select(i => new Blueprint(i)).ToList();
            Log.Info($"Loaded {Blueprints.Count} blueprints");
        }

        public List<Blueprint> Blueprints { get; set; }

        public int FindQuanlityLevelSum()
        {
            int sum = 0;
            foreach (var blueprint in Blueprints)
            {
                var maxGeodes = FindMaxGeodes(blueprint, 24);
                sum += blueprint.Number * maxGeodes;
                Log.Info($"Blueprint: {blueprint.Number} Max geodes {maxGeodes} - running sum {sum}");
            }

            return sum;
        }

        public int FindProductOfFirstThree()
        {
            List<int> maxes = new();
            foreach (var blueprint in Blueprints.Take(3))
            {
                var maxGeodes = FindMaxGeodes(blueprint, 32);
                maxes.Add(maxGeodes);
                Log.Info($"Blueprint: {blueprint.Number} Max geodes {maxGeodes}");
            }

            return maxes[0] * maxes[1] * maxes[2];
        }

        public int FindMaxGeodes(Blueprint blueprint, int maxMinutes)
        {
            var races = new List<RobotMiningRace> { new RobotMiningRace(blueprint) };
            int minutes = 1;
            while (minutes <= maxMinutes)
            {
                Log.Info($"Blueprint: {blueprint.Number} Minute {minutes} - race count {races.Count:n0}");

                if (minutes == maxMinutes)
                {
                    foreach (var race in races)
                    {
                        race.Tick(new RobotMiningRace.BuildOrders());
                    }
                }
                else
                {
                    var nextRaces = new List<RobotMiningRace>();
                    foreach (var race in races)
                    {
                        var buildOrdersOptions = race.SpendOptions();
                        for (int i = 0; i < buildOrdersOptions.Count; i++)
                        {
                            var nextRace = i == buildOrdersOptions.Count - 1 ? race : race.Clone();
                            nextRace.Tick(buildOrdersOptions[i]);
                            nextRaces.Add(nextRace);
                        }
                    }

                    races = nextRaces;
                }

                minutes++;
            }

            return races.Max(r => r.OpenedGeodes);
        }

        public int FindMaxGeodesWithSplit(Blueprint blueprint, int maxMinutes, int splitAt = 100)
        {
            var races = new List<RobotMiningRace> { new RobotMiningRace(blueprint) };
            int minutes = 1;
            while (minutes < maxMinutes && races.Count <= splitAt)
            {
                Log.Info($"Blueprint: {blueprint.Number} Minute {minutes} - race count {races.Count:n0}");

                var nextRaces = new List<RobotMiningRace>();
                foreach (var race in races)
                {
                    var buildOrdersOptions = race.SpendOptions();
                    for (int i = 0; i < buildOrdersOptions.Count; i++)
                    {
                        var nextRace = i == buildOrdersOptions.Count - 1 ? race : race.Clone();
                        nextRace.Tick(buildOrdersOptions[i]);
                        nextRaces.Add(nextRace);
                    }
                }

                races = nextRaces;

                minutes++;
            }

            Log.Info($"Blueprint: {blueprint.Number} at Minute {minutes} we have {races.Count:n0} seeds");

            int seedNumber = 0;
            List<int> maxes = new();
            foreach (var seed in races)
            {
                seedNumber++;
                maxes.Add(FindMaxGeodesForSeed(seed, seedNumber, races.Count, minutes, maxMinutes));
            }

            return maxes.Max();
        }

        public int FindMaxGeodesForSeed(RobotMiningRace seed, int seedNumber, int maxSeedNumber, int minutes, int maxMinutes)
        {
            var races = new List<RobotMiningRace> { seed };
            while (minutes <= maxMinutes)
            {
                Log.Info($"Blueprint: {seed.Blueprint.Number} Seed: {seedNumber}/{maxSeedNumber} Minute {minutes} - race count {races.Count:n0}");

                if (minutes == maxMinutes)
                {
                    foreach (var race in races)
                    {
                        race.Tick(new RobotMiningRace.BuildOrders());
                    }
                }
                else
                {
                    var nextRaces = new List<RobotMiningRace>();
                    foreach (var race in races)
                    {
                        var buildOrdersOptions = race.SpendOptions();
                        for (int i = 0; i < buildOrdersOptions.Count; i++)
                        {
                            var nextRace = i == buildOrdersOptions.Count - 1 ? race : race.Clone();
                            nextRace.Tick(buildOrdersOptions[i]);
                            nextRaces.Add(nextRace);
                        }
                    }

                    races = nextRaces;
                }

                minutes++;
            }

            return races.Max(r => r.OpenedGeodes);
        }
    }

    public class Blueprint
    {
        public Blueprint(string input)
        {
            Number = input.Parse<short>(10);
            OreRobotCost = input.ParseAfter<short>("Each ore robot costs ");
            ClayRobotCost = input.ParseAfter<short>("Each clay robot costs ");
            ObsidianRobotCost = (input.ParseAfter<short>("Each obsidian robot costs "), input.ParseAfter<short>(" and "));
            GeodeRobotCost = (input.ParseAfter<short>("Each geode robot costs "), input.ParseAfter<short>(" and ", input.IndexOf("obsidian.") - 8));
            HighestOreCost = new short[] { OreRobotCost, ClayRobotCost, ObsidianRobotCost.Ore, GeodeRobotCost.Ore }.Max();
        }

        public short Number { get; set; }
        public short OreRobotCost { get; }
        public short ClayRobotCost { get; }
        public (short Ore, short Clay) ObsidianRobotCost { get; }
        public (short Ore, short Obsidian) GeodeRobotCost { get; }
        public short HighestOreCost { get; set; }
    }

    public class RobotMiningRace
    {
        public Blueprint Blueprint { get; }

        public RobotMiningRace(Blueprint blueprint)
        {
            Blueprint = blueprint;
        }

        public RobotMiningRace(RobotMiningRace other)
        {
            Blueprint = other.Blueprint;
            OreMiners = other.OreMiners;
            ClayMiners = other.ClayMiners;
            ObsidianMiners = other.ObsidianMiners;
            GeodeOpeners = other.GeodeOpeners;
            MinedOre = other.MinedOre;
            MinedClay = other.MinedClay;
            MinedObsidian = other.MinedObsidian;
            OpenedGeodes = other.OpenedGeodes;
        }

        public RobotMiningRace Clone()
        {
            return new RobotMiningRace(this);
        }

        public short OreMiners { get; set; } = 1;
        public short ClayMiners { get; set; }
        public short ObsidianMiners { get; set; }
        public short GeodeOpeners { get; set; }

        public short MinedOre { get; set; }
        public short MinedClay { get; set; }
        public short MinedObsidian { get; set; }
        public short OpenedGeodes { get; set; }

        public void Tick(BuildOrders buildOrders)
        {
            Spend(buildOrders);
            Collect();
            Build(buildOrders);
        }

        public enum BuildOrders
        {
            BuildNothing,
            BuildOreMiner,
            BuildClayMiner,
            BuildObsidianMiner,
            BuildGeodeOpener
        }

        public List<BuildOrders> SpendOptions()
        {
            var buildOrdersOptions = new List<BuildOrders>();

            if (CanBuildGeodeOpener)
            {
                buildOrdersOptions.Add(BuildOrders.BuildGeodeOpener);
            }

            if (MinedObsidian <= Blueprint.GeodeRobotCost.Obsidian && CanBuildObsidianMiner)
            {
                buildOrdersOptions.Add(BuildOrders.BuildObsidianMiner);
            }

            if (MinedClay <= Blueprint.ObsidianRobotCost.Clay && CanBuildClayMiner)
            {
                buildOrdersOptions.Add(BuildOrders.BuildClayMiner);
            }

            if (MinedOre <= Blueprint.HighestOreCost && CanBuildOreMiner)
            {
                buildOrdersOptions.Add(BuildOrders.BuildOreMiner);
            }

            if (MinedOre < Blueprint.HighestOreCost || MinedClay < Blueprint.ObsidianRobotCost.Clay || MinedObsidian < Blueprint.GeodeRobotCost.Obsidian)
            {
                buildOrdersOptions.Add(BuildOrders.BuildNothing);
            }

            return buildOrdersOptions;
        }

        private void Spend(BuildOrders buildOrders)
        {
            switch (buildOrders)
            {
                case BuildOrders.BuildNothing:
                    return;
                case BuildOrders.BuildOreMiner:
                    MinedOre -= Blueprint.OreRobotCost;
                    break;
                case BuildOrders.BuildClayMiner:
                    MinedOre -= Blueprint.ClayRobotCost;
                    break;
                case BuildOrders.BuildObsidianMiner:
                    MinedClay -= Blueprint.ObsidianRobotCost.Clay;
                    MinedOre -= Blueprint.ObsidianRobotCost.Ore;
                    break;
                case BuildOrders.BuildGeodeOpener:
                    MinedObsidian -= Blueprint.GeodeRobotCost.Obsidian;
                    MinedOre -= Blueprint.GeodeRobotCost.Ore;
                    break;
            }
        }

        public bool CanBuildGeodeOpener => MinedObsidian >= Blueprint.GeodeRobotCost.Obsidian && MinedOre >= Blueprint.GeodeRobotCost.Ore;
        public bool CanBuildObsidianMiner => MinedClay >= Blueprint.ObsidianRobotCost.Clay && MinedOre >= Blueprint.ObsidianRobotCost.Ore;
        public bool CanBuildClayMiner => MinedOre >= Blueprint.ClayRobotCost;
        public bool CanBuildOreMiner => MinedOre >= Blueprint.OreRobotCost;

        private void Collect()
        {
            MinedOre += OreMiners;
            MinedClay += ClayMiners;
            MinedObsidian += ObsidianMiners;
            OpenedGeodes += GeodeOpeners;
        }

        private void Build(BuildOrders buildOrders)
        {
            switch (buildOrders)
            {
                case BuildOrders.BuildNothing:
                    break;
                case BuildOrders.BuildOreMiner:
                    OreMiners++;
                    break;
                case BuildOrders.BuildClayMiner:
                    ClayMiners++;
                    break;
                case BuildOrders.BuildObsidianMiner:
                    ObsidianMiners++;
                    break;
                case BuildOrders.BuildGeodeOpener:
                    GeodeOpeners++;
                    break;
            }
        }
    }
}
