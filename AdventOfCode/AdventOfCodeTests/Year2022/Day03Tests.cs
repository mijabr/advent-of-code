﻿namespace AdventOfCodeTests.Year2022
{
    public class Day03Tests
    {
        [Test]
        public void GetDuplicateItemPriority_ShouldReturnThePriorityOfTheDuplicateItem()
        {
            var organiser = new RucksackOrganiser();

            var result = organiser.GetDuplicateItemPriority("vJrwpWtwJgWrhcsFMMfFFhFp");

            result.Should().Be(16);
        }

        [Test]
        public void GetDuplicateItemPriority_ShouldReturnThePriorityOfTheDuplicateItem_Also()
        {
            var organiser = new RucksackOrganiser();

            var result = organiser.GetDuplicateItemPriority("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL");

            result.Should().Be(38);
        }

        [Test]
        public void GetDuplicateItemPrioritySum_ShouldReturnThePriorityOfTheDuplicateItem_Also()
        {
            var organiser = new RucksackOrganiser();
            var rucksacks = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

            var result = organiser.GetDuplicateItemPrioritySum(rucksacks);

            result.Should().Be(157);
        }

        [Test]
        public void GetGroupBadgePriority_ShouldReturnTheBadgeGroupPriority()
        {
            var organiser = new RucksackOrganiser();
            var rucksacks = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg";

            var result = organiser.GetGroupBadgePriority(rucksacks);

            result.Should().Be(18);
        }

        [Test]
        public void GetGroupBadgePriority_ShouldReturnTheBadgeGroupPriority_Also()
        {
            var organiser = new RucksackOrganiser();
            var rucksacks = @"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

            var result = organiser.GetGroupBadgePriority(rucksacks);

            result.Should().Be(52);
        }

        [Test]
        public void GetGroupBadgePrioritySum_ShouldReturnTheBadgeGroupPrioritySum()
        {
            var organiser = new RucksackOrganiser();
            var rucksacks = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

            var result = organiser.GetGroupBadgePrioritySum(rucksacks);

            result.Should().Be(70);
        }

        [Test]
        public void GetDuplicateItemPrioritySum_ShouldGivenThePuzzleAnswerToPart1()
        {
            var organiser = new RucksackOrganiser();

            var result = organiser.GetDuplicateItemPrioritySum(_puzzleInput);

            result.Should().Be(8401);
        }

        [Test]
        public void GetGroupBadgePrioritySum_ShouldGivenThePuzzleAnswerToPart2()
        {
            var organiser = new RucksackOrganiser();

            var result = organiser.GetGroupBadgePrioritySum(_puzzleInput);

            result.Should().Be(2641);
        }

        private const string _puzzleInput = "lflZfgnSnlmmlgGfjGthQPtLNsQhvbHLLpSS\r\nzrCVDVFMJTCTcCJMwCThWbtbpbWpPbtbHPLQssLsHP\r\nrBFcrwFzFwwVDcDrzTzJfnRGjllBdGZnnZfhqmdn\r\nFjpnFRDmbRtnbJrFJmSTsGShWVhGqGVVsmqs\r\nZwPvNPdzNZwfzBNLdNNNNcLvhnQhqMTVsTGSWSqGqTdVWhMT\r\nvgLZHfvLffNLPbggnrbFpJnCbC\r\nhzJzGjGfqmGtDQtDSvVV\r\nplpcMBNBcCTlTgCMbvtrsSVsVJDJlrwDQr\r\nMcHBMMcTTHgJnWqnRqjzZnnRzR\r\nppvsGZhDGprrSjSllwfZ\r\nTTFMMFJMgMHmHmdqdSvNqlSSSNJv\r\nmgBPHTRWFRVcpvsVttppbv\r\nZZDssfMDMtqqppZLLJzmzSTwNJplTSgpgm\r\nBdCRRHFRbccWWBvBHCdcJVngNVSvTgVNzgNNVmnz\r\nQHFFrBdcGtqPmmQh\r\nqLvQFRgLSSNgqQvRrqLTQvLttwDBFWDwjwFttDdlBBwBwM\r\nnbsmZnbmHbZVCGPVmHWtwlStBDtwBMtwWHMj\r\nCnCbhGCPpPCSnZmrgRNRqNRrLNgrzh\r\nvgLWWHRNLnWwLggWzwLFFzMmBMRMhMhTbhsmmsbbmQTm\r\nrScpJJDDpjtSDPPPJDpjqPCHBBtlTdblmmlhBsMMmTsbmtsl\r\nGHZHCPprSSwgvWNVwVZv\r\ndMrCMJMqvtdFwcjczjQzThtm\r\ngGbLblLpZlHvllQhlQwcjT\r\nGHRWvPRbPHPRvNGbvdRBqdqBBfRqBqnrfF\r\nVsHcljlbhmHbHHlcjVcVShJSCdJCfMrMMQDfRNFCfMRGfNrQ\r\ntGtvLtpgBTGvDMMRdMMgdCNM\r\npnGnGqGtvtzTLjWqmSSjHhWhWs\r\nNJTDntDNDVjNnjBfjjjcCZCZcVqCSCLqcSScCc\r\nzvhgRgQvvdllgQbHghlvHrRHSScBCRqqwCLGqSMCZCGGGqMZ\r\npvvrHzdgvlgzQphQsDFmnsNTTtjfjJJmPB\r\nScnSZSZZlmjmHjjWHHWZftJVJpppwtVVnLJtnptnwt\r\nCFFlQBbbPQqrBwJrJJrGJD\r\nPgTqRddFzgdRPFFbFgqQFgsSjfHWfSHmSMWcjZlmZmjTZM\r\nlzBRtctbnBRBRBBWnDnDWjlLVvwGMrvwrHHQHGmDvHQvHGrV\r\nFsTgFCTSgsCNspzhCGMfTHQVwVMfMmMmrH\r\nhSdSFgghhqpRbLqjntqnPz\r\nDCDnNGFFDQdQmVDNdFVNFccpJLHWSvPLrvvvPtGGhSttLv\r\nsBgTzzZqrBlfljslWBhvHSvPBhSBJSSL\r\nlRlTgMzlzrwRrnmbCMCFnNVMnc\r\nMJQJMJHBrsdrHwts\r\ndbbSVGgbjVqGTVfqddCTpmWWcprgNgWmcWwWswpN\r\nLPdGGdVGPCVdLBlBMlDRRRMD\r\nvdcwZLTdTFFRDHVgmpppMmqZ\r\njGPzCnQPjlsDVqDpqDHbgP\r\nBjWJrlGQQzrCzBzlzBCGBznzwNRNcwLJdwTJFTHRSTvtLcNN\r\nngrgqTjJJZnjFJpnqnnVTLzBbbHbLQdLHLHbrdHdHG\r\nlNcltCCtvftfWssPbMQdMBzhbbcBDLdh\r\nPRtWsQCmWsmSsCNCSvCSWlspwgqjqmqjTpnJZwnZVpFwgq\r\nPjWjGDCjmrmWPNmvWDWFmgCNfVJRLfJRfLDLJQlfHplpRbfR\r\nMtZMtcSbccZshTtQTVVTpzHlLRRQLV\r\ncZhbwMnwqsqnhnqtMBnvNFrnGPNPPmgPGCgW\r\nWBjWjWjqZwQJnJZCZZbf\r\nStHSDRPHHcTrTrJpLCCMbrqnJn\r\nRvTTvGqcqTFvSvSRDHvRjlhgWBWBdhjwjGgNjhlj\r\nFSbCqcFsbCPtrcrqhCScbshMjHDGGWBLHBnjGLPBHGGBGnHj\r\nflQdlsgQgGnQHBHjDn\r\nvllgRZdmvsvpgdwZgzJdwRmprqccSFcSShJbTSttqMCrCCch\r\nGwwgCtvHgwcHVVDqpWdfnqVv\r\nsllBsSNBjSrLfqhLgjfqhL\r\nZbQbZQzgQQPSblBggNQRHGZHHCmwmHFGGcwtJm\r\nCmGVGBTVTmmTWTNLLCVgCSFvDQppQQDDnDQDJpMggfnQft\r\nRrtdqtldPbHzRbnjRfQZjJfMDnMj\r\nwcwhccqrdrrlFmLGCwCtSwtL\r\npzZznZphZnpcNWSwGwVVPzrPrG\r\nlgFllLLltgbDsrBCwrjWGmwmtw\r\nMgJbDLlMQRJccchrhc\r\nwbbjzZhdGDwLzZSBWqqHmZgssCWqFtMZ\r\nVRJccfvPlTTlQlHQCWQhMMhCCHqQ\r\nRlVfVJcPTVTfvvvJfNJVlcBjGjwhSLdBNGGnjLLBwzGb\r\nbvpqHMVTTpZnqnWRQQQw\r\ntfhFFdSFggfhbldhhZcnRscRcQmnRs\r\nDPzgFJzFLfFbFSgPFgdPglMHpvBpHTCMGpjvMMpLvvNG\r\nJggGLQgQpLpSPRJgGPSnGlFTDBjjRFvRjtBFjWvFjqRj\r\ncmHhZcMHcWjrTBjrvm\r\ndbHwdNNHhwTNThZHdlwQJJwngpgnJGnSPw\r\nDbZjVfjVLhZDLpWPHpMZPmmGNp\r\nlFcJJGcFqnBFqwJCHHMmNHPsdCNp\r\nBlwccRQtBwBrwLGbGhGggzLgzR\r\nRBhZPjlWqgbNbgGLBr\r\nMzSmSzpFdHwpswzzHnzjnvLCbgtrtLGLbJLLJNtJtbwJ\r\nMsSHdmMdpFfmFjpfcPWRhRVZfWQThZ\r\nmqmssPCFhhsJccVg\r\nFTttfwdjjHznJgfngpnc\r\ndNFTjQNRtRNQldRNrRdHMRrlPZqCGlGBCqqZmmbPqDmDCmGW\r\nZJVRRZZJRcvmPhCJrvhm\r\nPPWQDTfWbnnstlCGvjGrWMGMvr\r\nTbbwddndsnsfDpwFqZFVHBVPqc\r\ntFmpJmgJJgmFDWgRgFrrlGSltSQvZChMtCMM\r\nTLcZHsjLVNBwGQCCGlsCShvh\r\nnqNdwwccBwVLwjjDznZzppbgzFZfDF\r\nqsTqCCCszjlqTssBShlQSSZFgZZhgB\r\nLDPmVgDDJdLPrPgLgPZSFZQfhQGGBQJcSFJS\r\nmvmVbVvtggVtvgdLVvtmptCsNTtjRnpRTTjpsqCp\r\nBdNPLnmFvLFNgnmBmnFGnwSZZZWwqWgqjwWssTHWSS\r\nbJhMzhbVMbDCcVpZtjHMqTMwtttSjH\r\nhzclfCppVqQfbzQVbpzPQLNFBdrvdNGGBnmrmP\r\nnLVLzBDJCCHqdLncqVJgSsDlGsbssmvvvbvbff\r\njMNHFWNTZZNwMPrPWrrPMMrrvSllbgsllfgbgvQsvGmglZbv\r\nRjPjrjRPtNrwHhBtncCJtJtL\r\njbhhjhNjvqNbmjMjqhtCFdmPFdlzJzfFfJQJfR\r\nGBBZWrZWgpSsnSngrrSgHzFzFFdClzfFQFlRZftQPR\r\nTrGTrGWHpHWGHWVWsngprHpLbLLVvcqMcNbVNLhwVNbtNb\r\nsQDvDmDLQFDRsdchzhBczLhhPhVz\r\nMbGGMjjGZSjvfHvHSbfwBqcPnqqcPVhPNnqnzjcn\r\nZwMMHrWvSHbfJfTrbJwSMMfMsQDtsFRptlpdCRpWmptQDRmC\r\nTwMHdcTznLqzTrHdzzzHTdgMRQWRhJhNjjvgQvQQWNjl\r\ntbfsVbDCVSSDtSPQJWPvRNhQtghN\r\nFVGBpGCVFCbfCbVbZCSHqmwqcqLcdHJGwHqqTd\r\nlTlGfjLGwHNMggscsDRwsC\r\nMrFtrzZZPZrtVQtnrrFdQhhDPDSphgDRhDcsCCgWpW\r\nZJmJVzVVJFHfGbqJGMLv\r\nzsFZVjzlHPfTzGfLGt\r\nmdrrmdMMcBcmNqNbPqfRDLPWPlqTWD\r\nBNQhmmrBrQghgSmNBQQSmvwssjZZSJHljJFFHZJvZV\r\nrLZCsZdMJfdNCsfZMrLdFmssnwgTRQgBBwgRwcngTNVRVQjV\r\nStqDHlStDPgRTqcwjT\r\nGlDGDhbpHhvSHWlzbWlhpzhJdrFLrCLmvdmFZsmJJjJfdv\r\npJHJMJsJjSMFdHhszFvMhlmmGNlSmmBGllWmVlwcTw\r\nZqZRDrZCZDtPDPDrCngrnnPQGVmGHVBWGWtGmWVwVlmTlGNl\r\nZQPgRqrrQPqLnrLMvLphHdvdjpJddb\r\nNwbBjljFbcjtTcccqW\r\nRHZrPHPpNgZTzTqc\r\nsfrPdmPdpsmPPPrfQPVGlwGVBwbGVnFlNQCG\r\nhQdNTlzhdTvrhdnTBqcWBLsBHgWQgBPg\r\nzwzRDbDfqZBLHDLB\r\nwFbFmjjRzfmjGGMGMfmJwwGCCnvNhpvSCNnrvJvCprnnSp\r\nzshNNJbwGFJfGJzzzNRnHGnCnRHcRPgTmPmn\r\nLMDVtZLStrrZClBrVDllLSBWRPTPPRRPmgWPVmPTPHTWgR\r\nSDSqLMlrtLlLtrBqBdlMZjvffCNzwvhjvvzhdfNhvf\r\nSLQmGBmhLSLQTBGBGwdwpJjwwQjwcVpJZJ\r\nsNrWrWPNbHghrbgnNNzbWbFWdZpMpzVpdMZMzMMVZcwwJdwd\r\nfrrPNNWshWhhHDvDGDRSBSRvttqv\r\nFJqpgvhJJRjFjZTqDsMHrzwjsSsSszMrMm\r\nPPPQWGtnbbfBmPsFswwsMrcc\r\nQfBtbldtWQfbWbnfGlFqZppvpFZZLhFlpq\r\nZqSMZHHCMpHTZTWmFTFZPZQJBgVGVJQvVVSDBvBtcBBG\r\nRNsndwsNjsbsgGCgjQBttcBg\r\nNRszRRNzLNNNwNfhCCrfdmTqFZllFFHFFpWhlTmWpq\r\nllbbzDmSspGRpHpzsldzRRsVtFBBFJMMVVFLTTTMVtLTDM\r\ncqgjqvNgvqCjQZqgGGnhMTnMJVLBLMtFhhVFWB\r\nPfGGvQrPCjvjZgGCCCZZZbSmmmHlRpprlHrHwssSRr\r\nmRmpFpWpfMMgLnmS\r\nCdCsqzdRzqStLjSqfMnL\r\nwQRHdTzCQbzCwsTrZBlFZGpVlpFGQD\r\nqnMTnTVSTPTHTHcMZMvVpmppmFmVzFLLFLlFpG\r\ngBjDsjRRwhDDghthwwWZwLmpmwWWLWLbGZ\r\nNhZtZtBgPTNJJNTS\r\njLjjmpHvzvZrfzQjmfHHWrfbqblLsSlTsqsgqPJbPqVglb\r\nFBcCwDwtwgcgnCwcGchtJSsRqVRVJPPqDlbSDRPq\r\nMBhthFNtMGCwhcwnpQfWjNrQprpvzpgQ\r\nRfCnWfnhCbwHgWjzBgzB\r\nPsVqDsSTshsgszpsph\r\nDPDvTVtTShhSZhmqSvLlQJFnQJJZnbCnlCCZ\r\npRRdJngltnwwvTNSWqWffqgBqD\r\nHQGcsdrjzMDDBfGMGG\r\nFLhsdbzCLLHjhntpVnRPRvZV\r\ngZNwQHHNRlGvhvhGRvRb\r\ndpSSBDrzdCfcSzfrzZrfCfMbthWWWPttDthvMFWvvvPj\r\nZdpBpZCrssBJZfSJBzBdCTcnmQwmnVVlmqTQTTQlHLwNnN\r\nssCpTttVVVpzZDVvRpCsRtDgWBWBBFBJvvJHMBghGghrMJ\r\nlwLmNNLwSblbmSQLfhJHZgHrHhhJJhHHmW\r\nQLSdbdPqndlNlLdSLNQncpRtRTcRVTPPZRCjVCcc\r\nwzzJclzcTThvWSSCqRlQSsNN\r\nrDpVjpVVDpsQSRDRfQmm\r\nGLbjrLpFbgLVLLgdbjVpchcFZhvBwJvtvtJcZwRB\r\nwPgZgLVMfWVTgmTZZZftJjtfjtJCcdpjdCqc\r\nzGGbQQnQGvBBhGQvvvBBSBvQdhdqqCpdddDmJlCcDjCtJdmJ\r\nHszzHBzQBSmGSwTWgswZPWTVgZ\r\nGDFvzCFdrszSdNJrFfjjfqZjRfsjpqmcwZ\r\nWbbVtVnBPWMgBLMBnQQnBQHcjfjpZRwqcwMfcNTZRqqNmT\r\nWQQnVVPHtggLghWWhHnPVQbvlJhSlrvJDlFGJDdDCzGNFF\r\ndVhTBjBHtTVqWRJZRqhJZQ\r\nbrSDTbDfcCwDzfCSbwMQnlqCRJnMgWWnZngM\r\nDFwNSrwNwbDzbFTTFtjmBpVdGpHs\r\ndPQfdfTzDrFDmFDBgBFj\r\nRlJRclcswJRvnwPcpjbjbbCZjFjbBmsbFZ\r\npqncGlcRJpHGpllGHhvPhRTHrQrttVVfrdQzfrTdftfV\r\nRCzTzRMTfCfRRDzRfhSmZZlCslBbZZBVtZBZsqBL\r\nnvvJPpdcFnPcWnFnVZvBqVlZMbZBNVlV\r\nFpWPMdjdPhSTmwfSjD\r\nNDJjNHLLNWjcLLWCLJLZjLDtRqqtgtMqgtqnRqnSRgggtZ\r\nBwrlfFwmQwhwfPBFhsBdFmbQggCgqQVtbRSqttqMngnp\r\nllPPwsPlGshBJGWJLcHvCzNv\r\nrBvTmwdTSbnrvVWsWVftGfJQGT\r\ngNRLLjlPRWnFVRFDFW\r\nlpCpPNZqZCdvdppnSnBr\r\nShRdCrJgHClZJtZDGMMz\r\nLvqVVTTNbVPLQNFTnwwMtzFZGDDwmtnM\r\nVLbNvpPvTNVqVbbNpbVPGNLPrRWrcRCWdSrCjWSHcHSdWpCh\r\ntNmZnLSZPFLDnLTmhJMWczQdhmWhWH\r\nbGqbgrpsCsWhcChNQfJz\r\nvwlNbppsRGRRSSSDvjTjLZjZ\r\nzgMZhgfBtftSZQQmLHpSWH\r\ncdqcqnrJVGjjqPVjrPnfpJmsQHQQpsSsbsSDmm\r\nNNnrNqNlrNcPTlBvBvgggfMv\r\nllPrrLHBHCrRRBjrHCjBdrPmvJZzZgZbmgJlZmZhMhhmvh\r\npNDstVtNtGFNSDFScQtfwzzFJwmJhgqzbMwqZJmh\r\nfpNsptGtQcTsSTccprddCWPrWdTRBMMCMd\r\nTTtDVqTsTcJFgbCqmbCq\r\nNWZQnllzfBFZPBGWQGzFPFRNNgHbHrrwbNrmCbggJRHR\r\nnBZjGFjMQBMPZnjfWjstpcctttvVtcTttMpL\r\nqphVCCwnHqhnRVznFwvLtBTLDTWZtwLWWS\r\nJmdlsdlsjfJfrtjTcvtctDZSSB\r\nrsmfPGbrPbPJfPmrsgMrdJdlFTHhFCqhNqVHnNHHCFznhphG\r\nJsWFMJJzrhSSdFdldmmdmdQc\r\nqLLgCVTgLbBvqsQPVdQGcRRmQmdc\r\nbBCBgCCDbLDqTvqqjpShHfzrzMfjtHHSHsfz\r\nnvFSBFlvvgQFFBzQnlQglmRRzqwsrrMJJMrsMqrfrwzf\r\nCjZNCNhLDNbPZZLZZhwVjpcfrqRhsdJqdsshRTTdqJrJ\r\njNNDDppjpjDWNVLCVVDpGVVPBFtlSQFWvvQvSSQHSgwQnvtB\r\nWhrQWBRWwhzgmpnSpH\r\nLqMVsJVvFMJLJMsfNjsTJvCgFbSmzgpSHzmngHbGPCbm\r\njvMjjtqVjTRnwZQwBWwt\r\njfTWSGSTTWhgcngQfbtJfNzztBQBzz\r\npVVwsdppRVPLVmPsVVHsjPLPzQdzBzQFzFBNNrJZZQBzbbFF\r\nVmsqHmjHmpvGDSWDvlclSl\r\nPNZfTFSFfTFGCHqqmbFm\r\nWjzRWrjVgnjzplrWWjJVppgGPGsgstmPCCtcmssQqGQt\r\npzjzJVvnzJjWvpPlnVRVrvnlTDLNNhwfdNZLfMZLwLhTNvTw\r\nQFrQZMFVrVpVszzcNTdMRCCb\r\nSvljGmlvLfwLhLLLHlHdNzsRthhbbRccRCRNbC\r\nLfwlDmlvGBSjjlLLgpPpFJqgQndQgZBJ\r\nRBjPRHdjPfqQcfhcdv\r\nSngFcJZJlcnctSlhhsQvGsDGDsDnfs\r\npSmFgSWNJFNtStrmNtpCCjPVcbjjHbcWTBHBHL\r\nvGjqCPqNPGFGNftLwmZwfQNTLp\r\nhrdBCSHcCJJcCBShJswmLQpLbbQZTLLJmmZp\r\nBdHHSzrBWdzchzzCcdzHddcDVWFnjPjllGggVlWljPFFFWPM\r\nhBtZZnpbhbPZJbnhDtPnpBtpfjfNNzrrCzjFzFzFTjfjjWzJ\r\ngHllMqRSmqcqMTdggMqHlcFzRrFQWNfvrRvzQrWjWvWf\r\ngwqlgHmmdsgwlwMHZtpsbBbtDBThbBht\r\nCsDLFFLFCvczsCsJrCrJJLRgbQQgmMmPbDDQbPnMgMmg\r\nVlwNBNVhjNVNWBwWjtbRMRZzPmQnfQMPnlZP\r\nVWWSSwGTwtwWWNVwwpqJJrcJGvzqCJCqJF\r\nwLwSSbzwCvddlvvlSj\r\nTHnQnnHttcvpQzrZRllZ\r\nsTntBHTnVbPbgzsbgL\r\nFwHgrHvFQQwpHhNhTBLdpNNNLd\r\nfCGqCVtszfSslCSzSGsfCssjNTqLTdmjNLBLdnTTTMTjTg\r\nDccfslfgRSSVVzlcSVtzDRVHwQZFrwwvwFWbbbRRWwrFJb\r\nCwwWwwFNRpFFpZQHtsmfqbQDTQTTqb\r\nVcjzLjGjzGjGjVjLdzqmDqHrsmsqGRrHqGqH\r\nRjdVlgdnljlBnSgPCpNwwMWwMM\r\ntCCtqtbPGzsSQVzQTq\r\nmzMmHMpRsRQTsFFV\r\nDpzDwgdMzMLppNmNpDpfgrbhLcGtPrbtrbrbhnbBcC\r\nBvsQBBBLvDQGjDvSQLTvrHprHlRpVlVllgRbRbHPqq\r\nMMMMCpfJFZZMmCzwpVPCWRtHgqWgqClgtt\r\nFwzmfzhFFdFcpvSDSBDThs\r\nfQrGQbFFFrHHtlHPclzzPLvc\r\nmTnwpNCCqMqjmCThpTpSvvtBczstlLznvsztsPPP\r\nmCpTNhmmpCqCmjmpTjmLCpSJQZVfFVrDVfffFFgfgJQFdbgG\r\nGmWjRBSfttcGfRcSclVVJqsTMllsgJVMVZwV\r\npPFNpfNCdNzCVMTTNqVssqJN\r\ndzPfHCLLhdjjLGRnmnmr\r\nGPhPfGWgggfslffPsVPGsqJMzLQJtBprwQJJGQwLpQrw\r\nZNdmvbDDbNvHbmZCcJQwMmzMwWWQrrwttp\r\nbvdDNdnvNbnHDdnDHHRSbnqhqhWfjWFVTVhRVjfjFTfP\r\nhTThfWNCDRfsVCDhpgzgbpPZZwbnZQns\r\nGSjGGcCBGmdjdSlGBcmZwzJzpPpJzwPwQbzgPd\r\nBGmcrcStcMMMmrSLmSMCvFVRFDhfFhhNDWWTqFqTvf\r\nZmjDTTbmqQCCQQSwvhsL\r\nFGVJPmPmtRVRsCvvRLwwhC\r\nJgdHJgmfbjzTpTMf\r\nfTbsVCsssgLNrfNrgm\r\nzQvzZlRvddvpNLpZrMNNLZ\r\nHLvWFHHlFQvzHnnlnvQqhzWvstBwbGVtstjGqjjwqGGCcwGq\r\nJNpNdzzdJhNnfNGBZLqZqlhvSZSG\r\nQswtcmmwwmTmwwcwZSLlZLDSvSvlBZQD\r\nFsVFBbFgFsPwtVBTwgTPcsmpzdNngfzfpCzJdzCJzNCndn\r\nqcvrLBppgpWWWgLcpzPfhNDqdzqwDDzwhV\r\nMZFjFnHFMHbMntMtnwStfddPhDffDfzDfS\r\nQmnjMZnlHjmnMGFnFlMmjlZWzLgsGgcrspBBLCBcgvgBRC\r\nsdfWHjZfrZrSPMCQ\r\nzqtWRDDDRMbrQJPQ\r\nzwhwzmqwzmFpWzvFqBmFvjNHlHfgVLBgdfVfNVjLsl\r\nlRlBTlvlZfhtbGBWtFBz\r\ncqCNjjqjrNrcNjwDqNPCVrSQStSWshFhtQhbQzGzmFCG\r\nHjPPzMcdNqjcNHMqPjdpgpZflfdgnTfdlvlJ\r\nVpwQJVRtHplnnwtppHhqWBCfVdNNPqPBPWsBDq\r\njzLZCrvvrZjZvqNffvDNDcWDWd\r\nLTrZZLFZbgTzgjZZjFClJhTHTplQpmnQlpmpQR\r\nJGJnSWLGSpWHVHwGGJHpZdwPdTTPMdTMDdlzccPMPv\r\ngqrrmtbrbgggqgBtqmRSrFgNCzvMDvlMPDdddvzBcPMMMDBd\r\ngjrmRgmtRggFtqjbhgbjrtnJJHWLHQWZZLhZsLLGHhSL\r\nBtTDNggLRPdWQHqggg\r\nwrVpVVlCJVGMMJVdHWSdPSqqRwSQSP\r\nvCVrpvvGjlphBRmZBhmBhBND\r\nlqDcZGcSSqSqbDnccSLJgHgLRfnvvJRLmvWJ\r\nFVCFPChQzVhmsFBgddRgJBfdNfJdfv\r\nFzCpmTQzjQCThppTSttqDccMTDGcDG\r\nQCSGBGCrCsMBTCQwMGSfvvLNNnnVLDlNVNDdVdlr\r\nZHtPffjWbqgtmnNdvljFnFhdVv\r\nJRWbmgmRJtmJMGGwSBBRRRfQ\r\nLqNrCfCQQhtgnPnc\r\nJWBrWrVlbWgbbtcb\r\nVwvTBprdrVJVNLNMNNqfqpjN\r\nbjVqdHrdqVHPsPNbqHbqNdjFGRwRGlttRtMtRtFFGMLHJw\r\ncfSpZnBZWQBZJlGRJJcwGMGL\r\nWWBhTMgDTZghVjgjssbrbddd";
    }
}
