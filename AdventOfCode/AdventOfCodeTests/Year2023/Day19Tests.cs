using AdventOfCode.Year2023;

namespace AdventOfCodeTests.Year2023
{
    public class Day19Tests
    {
        [Test]
        public void PartChecker_CanReadInput()
        {
            var partChecker = new PartChecker(exampleInput1);

            partChecker.Workflows["px"].Name.Should().Be("px");
            partChecker.Workflows["px"].Instructions[0].VariableName.Should().Be('a');
            partChecker.Workflows["px"].Instructions[0].Operation.Should().Be('<');
            partChecker.Workflows["px"].Instructions[0].Value.Should().Be(2006);
            partChecker.Workflows["px"].Instructions[0].Destination.Should().Be("qkq");
            partChecker.Workflows["px"].Instructions[2].Destination.Should().Be("rfg");
            partChecker.Parts[0].X.Should().Be(787);
            partChecker.Parts[0].M.Should().Be(2655);
            partChecker.Parts[0].A.Should().Be(1222);
            partChecker.Parts[0].S.Should().Be(2876);
        }

        [Test]
        public void PartChecker_CanSolveExample1()
        {
            var partChecker = new PartChecker(exampleInput1);

            partChecker.SumPartRatings().Should().Be(19114);
        }

        [Test]
        public void PartChecker_CanSolvePart1()
        {
            var partChecker = new PartChecker(input);

            partChecker.SumPartRatings().Should().Be(323625);
        }

        [Test]
        public void PartChecker_CanSolveSimpleInputPart2()
        {
            new PartChecker("in{x>3999:A,R}\r\n\r\n{x=1,m=1,a=1,s=1}").CountAllAcceptedPartTypes().Should().Be(1 * 4000L * 4000L * 4000L);
            new PartChecker("in{x<2:A,R}\r\n\r\n{x=1,m=1,a=1,s=1}").CountAllAcceptedPartTypes().Should().Be(1 * 4000L * 4000L * 4000L);
            new PartChecker("in{x<2:A,m<2:A,R}\r\n\r\n{x=1,m=1,a=1,s=1}").CountAllAcceptedPartTypes().Should().Be((1 * 4000L * 4000L * 4000L) + (3999L * 1 * 4000L * 4000L));
        }

        [Test]
        public void PartChecker_CanSolveExample1Part2()
        {
            var partChecker = new PartChecker(exampleInput1);

            partChecker.CountAllAcceptedPartTypes().Should().Be(167409079868000);
        }

        [Test]
        public void PartChecker_CanSolvePart2()
        {
            var partChecker = new PartChecker(input);

            partChecker.CountAllAcceptedPartTypes().Should().Be(127447746739409);
        }

        const string exampleInput1 = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{a>1716:R,A}\r\nlnx{m>1548:A,A}\r\nrfg{s<537:gd,x>2440:R,A}\r\nqs{s>3448:A,lnx}\r\nqkq{x<1416:A,crn}\r\ncrn{x>2662:A,R}\r\nin{s<1351:px,qqz}\r\nqqz{s>2770:qs,m<1801:hdj,R}\r\ngd{a>3333:R,R}\r\nhdj{m>838:A,pv}\r\n\r\n{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n{x=2461,m=1339,a=466,s=291}\r\n{x=2127,m=1623,a=2188,s=1013}";
        const string input = "qrl{a<3707:R,s<1335:gl,x<3173:vh,A}\r\nxv{x>3104:A,A}\r\ncc{s>2833:R,s>2427:vct,s>2339:R,R}\r\nhvz{m<2374:lfx,m<3387:xc,a<1085:qg,tsr}\r\nrrj{a<3364:R,x<260:lx,A}\r\nvbg{m>662:A,s<1158:R,R}\r\nrdx{x>1903:R,R}\r\npl{x<131:hm,m<1494:nd,x>238:A,xp}\r\nckb{m<2209:R,a<3037:A,x>3883:A,R}\r\nrdz{a>2663:A,R}\r\njx{m>1855:R,s>2178:A,jvp}\r\nhjh{x>475:cm,rqc}\r\nrqc{x<260:R,m<1542:A,A}\r\ncqx{x>1597:nhq,pz}\r\ngp{a<3338:kn,hcd}\r\nfd{a>1557:fmk,m>953:A,A}\r\nks{a<3176:A,s>1370:R,A}\r\npm{m<901:nlt,a<271:ptx,jbb}\r\ncdb{m<2049:nsb,a<3163:brd,s>2158:lnn,lmg}\r\nbx{s<779:R,x<88:R,A}\r\nqjh{m<3049:A,s>638:np,pbv}\r\nch{a>3043:ks,R}\r\nbrd{m<2186:R,x<662:nxk,dcp}\r\npmz{m<894:R,x<3724:R,a<2775:A,R}\r\nrfg{m>1244:A,A}\r\ncn{s<3571:R,A}\r\nqxr{x>716:lxj,s>1843:qsm,nxj}\r\nxq{s<2808:R,s>2861:R,A}\r\nvr{a<3755:A,A}\r\nnz{m>1189:lvp,A}\r\nhxb{s<3605:A,x>949:A,A}\r\nxn{a<3578:R,m>398:R,R}\r\nrj{a>443:A,s>2497:R,a<425:A,R}\r\nrtp{a>557:mbd,a<506:R,x<2419:A,rjk}\r\nqd{x<1236:mk,s<2937:R,R}\r\nsbt{a>3851:A,A}\r\nbdn{s>1458:lpk,rn}\r\nqh{a<3043:A,s>2651:R,m<1257:R,R}\r\nhzn{s>3026:jp,x>1647:A,m>2318:vk,ml}\r\nsdp{x>2756:A,m<928:R,m<1352:A,R}\r\nzk{m>925:zz,a>2605:pxc,x<1285:xkj,gmg}\r\ncpg{s<1090:A,R}\r\nqp{a>3590:hf,x<1156:jtj,x>1335:cr,rkv}\r\ngbz{s>2041:A,A}\r\nhg{s<422:A,x<3026:R,a<3799:A,R}\r\npd{s<1336:R,A}\r\nrf{m>3225:A,A}\r\nmdk{x<3206:A,s>3594:R,a>3395:R,R}\r\nklh{s<502:A,a>1328:R,A}\r\ntx{m<3309:R,A}\r\ngk{m<852:qgn,x<2335:A,a>3264:R,hx}\r\nsvq{x<2873:A,x>2914:hp,kc}\r\nkvl{m<1246:R,R}\r\nng{m>1993:jr,s<3279:R,s<3560:vn,A}\r\nnsh{m<2669:A,m<3118:R,x<1437:R,A}\r\nfrl{m>3364:pvn,A}\r\nxfx{a<3773:rkc,m>586:kf,m>304:gn,htl}\r\nmkt{m<644:R,a<651:R,R}\r\nclp{s<825:A,R}\r\nxtl{s>2395:A,A}\r\njtj{s<2124:A,R}\r\nhcd{s>1083:nvk,a>3564:hg,m>2848:R,dp}\r\nzcl{s<2171:tt,m>2094:A,s>2792:R,A}\r\njt{s<1619:A,x>2916:A,m<1099:R,A}\r\nqkp{s<1278:px,a>3497:A,s>1882:ffj,A}\r\nmml{m<3363:tlq,a>3196:lp,hzz}\r\nbt{x>3651:A,A}\r\nskl{x<1029:sh,m>408:gxq,vds}\r\nft{a<3037:tc,jvs}\r\nkt{s<1697:A,x<3076:A,x>3161:A,A}\r\nhd{a>971:A,s<2676:R,x<2406:A,R}\r\nknr{m<3346:lt,m>3670:jbk,zxz}\r\npz{x>1381:cqz,R}\r\ntpp{s<1171:R,a>3547:jg,A}\r\nvbt{s<1623:bkh,x<1101:kg,a>3062:mml,xjq}\r\nlnn{x<827:qmt,s>3206:A,x>1069:vkx,nqc}\r\ncb{s>3327:R,A}\r\nmgd{m>1674:ksr,R}\r\njpv{m<2575:kq,x<1532:qp,a<3638:gfb,hr}\r\nnd{x<230:A,a<3686:A,a>3755:A,A}\r\nhgh{a>538:R,s<1996:R,A}\r\njvs{x>443:A,A}\r\nhgn{s>1774:A,A}\r\nsvr{m<1194:R,a>187:A,R}\r\nmfz{s>3615:vms,a<2088:R,R}\r\nghd{a>298:A,a>114:A,R}\r\nbc{m>1419:R,x>2001:spg,s<3329:qh,R}\r\nrgl{s<316:A,a<1096:ff,m>3580:klh,qnx}\r\nhdq{x<604:R,A}\r\ngjl{a>1680:R,R}\r\ndsb{s>1233:mz,s>809:jfn,m>3233:rgl,hz}\r\nrzm{a<2334:R,s<1634:kmr,R}\r\nmj{m<849:jk,s<3403:dmj,gzt}\r\nvtt{x>1636:R,a>2858:R,s>2590:R,R}\r\ncz{m<576:R,a<3747:A,x<1407:R,R}\r\nzrv{m<1465:xpj,a>3380:mh,a>3125:cc,rsc}\r\npqc{m<1490:qxq,R}\r\njg{x>2647:A,s>1676:R,R}\r\nrs{a<3029:A,x>483:A,a<3164:A,A}\r\ntl{m<476:A,R}\r\nnf{m<1461:R,x>53:R,A}\r\nzn{x>3077:qrl,gc}\r\nvg{a<535:A,x<3580:A,R}\r\nlj{s>3153:xr,x<2411:dxp,knr}\r\nvfb{m>891:pqc,s>1713:cgv,x<3121:xxl,vx}\r\nnhh{x<330:R,x>601:R,m<1952:R,R}\r\ngl{x<3137:R,a>3834:R,A}\r\nhs{x<291:A,x>311:A,s>1579:A,R}\r\nfn{x>495:qb,A}\r\nhn{a>1922:A,R}\r\nntr{s<1871:A,R}\r\nxgx{s<3832:R,R}\r\nbs{s>2189:xdt,x<2812:rh,m<1931:qdj,gpc}\r\nfmk{a<1708:A,s>858:A,R}\r\nrkc{m>547:A,R}\r\nnsb{a>3154:A,rr}\r\nnxj{a<3128:tmz,tqm}\r\npxs{m<2213:gk,qkp}\r\nsp{m>2380:dbb,m<975:xfx,a<3848:kd,gfr}\r\nlnj{m<2229:A,m>2256:R,s>814:A,R}\r\ncr{m<3109:R,xlz}\r\nhdv{m<2642:ckb,s>421:fj,A}\r\ndbn{a>3150:R,m<1624:gd,gbz}\r\nzc{x<880:R,R}\r\ndcp{a>3100:A,s<2376:R,R}\r\nmdn{a>1602:bgb,m<2635:A,s>3125:rf,A}\r\npnm{x<978:ncl,s>3207:ck,ct}\r\nnsz{x>2518:vz,m<2176:lmn,a>2336:A,xh}\r\nsb{x<352:A,x>757:A,s>2955:R,A}\r\nsg{s>493:A,a>279:A,m>839:R,R}\r\nkn{x<3052:qfd,x<3152:R,A}\r\nzdc{x<3793:R,m<3058:R,R}\r\npkm{m>1037:ckz,s>999:bpj,mc}\r\ndtz{a<2459:tx,fc}\r\ntb{a<3095:dfx,m<1459:lnv,R}\r\ngn{s<2425:A,s<3424:A,x<333:R,A}\r\ngt{x>3230:R,x<2800:A,A}\r\nxjq{m<2905:mxj,dvn}\r\nqxq{a<335:A,x>3234:A,R}\r\nqgn{x<2265:R,R}\r\nmxj{a>2963:R,vtt}\r\nvds{x<1149:A,s<1145:R,A}\r\nhh{x>2385:A,s<3011:R,x<2155:R,R}\r\nnhq{s>1362:A,a>2891:A,R}\r\ntsr{x<783:A,a<1194:R,A}\r\nmq{m>3001:hgn,x>3935:mlm,s>1545:jvq,kj}\r\nmp{m<710:A,m>743:vv,gs}\r\nnt{m<1877:bpd,m>3212:gh,bj}\r\nzd{m<988:R,a>2969:R,xf}\r\npvn{s>2621:R,x<1735:R,m>3689:A,A}\r\nkf{a<3866:jdc,m<718:R,A}\r\npbb{m<1657:R,x>499:R,R}\r\njrl{m>983:A,s<458:R,a>668:A,mkt}\r\ndfb{m>1245:ghd,grb}\r\nnjd{s<2992:R,nl}\r\ngbv{a>902:R,R}\r\nckz{x>3062:A,a>195:A,A}\r\nncl{x<397:A,nxm}\r\npx{x>2218:R,x>2144:A,m>2839:R,R}\r\nnl{s<3516:A,s>3801:A,x>403:A,R}\r\nghg{s>1301:A,x<2691:R,A}\r\nqmt{m<2180:R,R}\r\nhmf{s>381:R,s>139:A,R}\r\nqm{s>3551:R,m<540:R,R}\r\nff{s<497:A,m>3617:R,x<2266:R,R}\r\ngd{m<1362:R,R}\r\nffp{x<1971:A,m<3079:A,A}\r\nct{a<2039:A,s>2903:htt,A}\r\nfb{s<1864:tg,sgc}\r\nkkh{a<1562:R,s<904:R,a>1725:R,A}\r\nhjk{a<3776:A,R}\r\ndvn{x<1692:gr,s<2897:R,R}\r\njdc{x<377:R,R}\r\nbsv{s<3634:A,A}\r\nfxx{s>2143:R,a>3887:A,A}\r\nhtt{s>3092:R,a>2263:R,R}\r\nzz{s<3092:A,gqr}\r\ngr{m>3456:R,m<3125:R,x<1479:A,R}\r\nxdt{x<2900:zrv,pf}\r\ncd{s>1295:A,R}\r\nzgc{x>3871:R,R}\r\ngrb{s>264:R,s>97:R,x<2915:A,R}\r\nmdc{x>1553:nq,dbn}\r\nqgl{x<3219:R,x<3361:A,s>2508:A,A}\r\nxxn{s>752:A,A}\r\nkc{x<2900:R,R}\r\nlz{a<1652:ng,x>774:qlv,ncb}\r\ntsl{x<1850:cb,R}\r\nmkq{m>990:kk,ltg}\r\ngtb{x<1799:stg,a>1726:fq,m>3208:gvl,rls}\r\nqrx{x<2528:A,m>706:R,a>464:A,A}\r\nzqv{s<339:A,s>546:A,A}\r\njd{a>2609:pq,s>3012:R,a<2510:A,R}\r\nvl{a>3592:R,s>2729:A,A}\r\nqlr{m<1435:R,m<1697:A,x>704:A,A}\r\nhqk{x>758:jpv,a>3561:sp,bdn}\r\nhz{x>1667:R,m>2821:A,A}\r\njpd{s<608:A,a>2896:A,R}\r\nrls{m<2855:khr,s<1026:A,x>2595:R,A}\r\ndhm{s>1937:R,R}\r\npdf{x>2266:R,R}\r\nmbj{x>1727:A,a<3673:A,m<3488:A,A}\r\nqsm{m<656:ft,m<776:mp,ffq}\r\nkbj{s<509:R,s<969:R,m>1256:A,A}\r\nqxv{a>2978:R,m>1584:A,A}\r\ndk{x>3754:A,A}\r\nrt{a>1155:A,m>3689:R,a>970:R,A}\r\nvpb{x>3851:A,s>2760:R,R}\r\ngxq{x>1137:A,R}\r\nqs{a<3656:xx,s>1787:kxf,a<3659:R,mln}\r\nxhv{x>1293:kkh,gnp}\r\nvpm{s<1403:R,x>1729:vl,R}\r\nvms{s>3773:A,x>3680:R,R}\r\nltn{m<3113:A,x<2711:R,R}\r\nxlz{x>1466:A,R}\r\nhdj{m>2827:brx,djd}\r\nnrx{x<3369:ltn,x<3655:A,x>3827:R,ghc}\r\nbvx{m<788:R,R}\r\nvc{s<1445:qxv,a<3123:dv,A}\r\ndsr{x>1448:kbh,R}\r\nzpq{x>1704:R,a>3077:A,a<2899:A,A}\r\ncrx{m<3470:A,A}\r\ngvv{s<2992:R,a>469:R,kkb}\r\nvh{x<3120:A,s<1621:A,x<3139:R,R}\r\ntc{m<414:R,A}\r\ngpc{x<3246:gp,a>3518:krs,x<3562:rl,bbn}\r\nnx{a<3856:R,m<1304:R,R}\r\nbrx{a<296:ctt,a<477:vhl,a<610:rtp,dsr}\r\npf{x>3493:td,s<3312:knq,mdk}\r\nrxl{m<1166:tl,a<1995:sbj,x<3577:A,vpb}\r\nkd{x<295:pl,m<1541:df,x<559:zcl,jx}\r\nbvq{a>2011:ppg,m<3551:R,A}\r\nvdc{s>1207:vfb,a<459:lm,a<637:dgs,pb}\r\nvct{x>2389:A,a<3269:A,a>3330:A,A}\r\nztb{s<388:kh,x>2951:zd,svq}\r\nxkj{s<3112:R,qm}\r\nlm{s>736:pkm,s<430:dfb,pk}\r\nvjb{a>2149:R,s>3499:hc,s<3316:A,R}\r\nkxd{a>750:A,A}\r\nksr{x<401:A,s<2419:R,x<583:A,A}\r\nxh{s>997:A,s<391:A,s<731:A,R}\r\npbh{s>469:ls,m>1551:R,s<259:zt,cz}\r\nrr{x>775:R,a<3112:R,R}\r\nxxl{x<2787:A,R}\r\ndb{a<3119:tb,s>1589:vq,a<3139:pgp,zm}\r\nsk{a<3242:bq,a<3352:A,m>2715:pd,cpg}\r\nczc{a>2658:R,m<485:R,A}\r\nrjr{s>3792:A,m>399:R,R}\r\nltg{a>2547:czc,s<3090:xg,s>3584:rjr,A}\r\ndrj{m>1093:vg,x>3516:A,R}\r\nvqz{s<2290:vc,m>1734:rdx,x>1893:bc,tsl}\r\ndp{x>3085:A,R}\r\nkj{a<3277:R,R}\r\nns{x>2988:R,s<1179:A,R}\r\ngdv{x<1772:R,s<1528:A,s>2015:A,R}\r\nntx{m>347:A,m>142:A,m<77:A,A}\r\nzf{a>2972:kfv,cfb}\r\nrn{s<813:spz,x>259:scp,ht}\r\nls{a<3629:R,s>897:R,x<1326:A,A}\r\njp{x>2020:R,m<2314:A,a<494:R,R}\r\nszl{s>643:A,a>654:A,R}\r\nrpm{s<1448:szl,R}\r\nbq{s>985:A,a>2994:A,x>3695:R,A}\r\nml{x>591:A,R}\r\nhzz{x<1669:A,R}\r\nptx{x<389:A,a>141:fgf,x<589:pbb,A}\r\nkgb{x<1587:R,s>1129:R,m<2314:A,A}\r\ntt{m>2007:R,s<931:R,R}\r\nfl{s>2420:fvs,a<3678:mbj,s>1613:R,lpv}\r\ncq{x>3325:A,s<1331:A,A}\r\ndfx{x<706:R,x<903:R,A}\r\nvn{x<1141:A,a>1523:A,x>1779:R,A}\r\nspg{x<2039:A,s<3405:A,A}\r\njcz{s>487:R,R}\r\nck{x<1294:pmq,a>2188:gzv,cn}\r\nbk{x<163:A,s>2092:A,A}\r\nzs{x>917:R,tzk}\r\nvv{s>3186:R,R}\r\njvq{a<3186:A,R}\r\nspl{s<2561:nt,m>2388:lj,x<1769:bb,msm}\r\nmn{x<3084:R,s>1566:A,m>646:A,A}\r\nds{s>2681:hbx,s<2150:ntr,x>355:rs,ld}\r\ncxn{s>3070:mfz,rxl}\r\nrsc{a>2911:R,A}\r\nbjd{a>703:R,s>635:A,A}\r\njn{s>806:A,m<1271:A,A}\r\nhtl{a<3904:dbl,R}\r\nrxr{s<1126:R,s>1698:A,A}\r\ngfb{a<3516:frl,vpm}\r\nrkv{x<1231:R,s>2006:dks,x>1300:zr,fp}\r\ngtc{x<2566:A,m<1673:R,s>471:R,R}\r\nkvs{m<1321:R,x>3726:A,R}\r\nxf{s<708:A,s>813:A,x<3096:R,A}\r\nxd{x<3816:A,R}\r\nvt{s>3175:xfg,R}\r\nbd{a<622:A,R}\r\nmlm{a>3153:R,x<3970:R,a>3032:R,A}\r\nxg{s<2859:A,a<2342:R,R}\r\njnq{s>1057:R,x>541:A,R}\r\njk{a>2327:A,a>2003:zpj,m>348:cj,pg}\r\ndv{x>1976:R,s>1952:A,A}\r\nxrb{m>1027:R,m>637:R,m<390:A,R}\r\nqg{a<985:lc,R}\r\nmb{s>1399:R,x>1301:dq,s<899:zqv,jtx}\r\ntlx{m>1015:tq,m<429:bjd,stc}\r\nncb{m>2367:cdc,x>426:R,x<157:R,R}\r\ncgz{s<677:R,R}\r\nzps{m>1776:R,A}\r\nrc{s>2621:xrb,m<1142:R,A}\r\njzv{m<2326:R,A}\r\ngzv{s>3726:R,m>1107:R,R}\r\nvq{a<3145:A,m<1346:bh,R}\r\nmx{m>2007:A,R}\r\ndjd{m>2506:lcb,s<1900:jbg,hzn}\r\nzh{x<3695:A,m<1169:R,pbg}\r\ntq{m<1629:A,m<1814:R,s<494:R,R}\r\nctt{s<1941:kr,a<132:A,x<2363:lnc,A}\r\ndxj{m>1817:tzz,jpd}\r\nnkz{m<1289:R,A}\r\nbtp{x<2374:qjh,nrx}\r\nkg{m>2889:crx,x<604:ds,a>2975:djl,zs}\r\nsn{x<1512:A,A}\r\ndm{m>529:R,m<328:R,A}\r\nmc{s<882:R,R}\r\nghc{a<1544:R,s>1053:R,x>3765:R,A}\r\nxl{m<2995:A,m<3217:R,a>1075:R,R}\r\ncqp{x>1382:A,s<3137:R,m<1467:R,A}\r\nmdx{m<458:A,s<869:R,x>901:A,A}\r\nxfj{x>1656:A,m>3750:A,m<3517:A,A}\r\nszh{x<591:R,R}\r\nvkf{x>3696:A,A}\r\npqk{m<2006:ghg,tpp}\r\nvhq{a>1187:mdn,hb}\r\ndjl{s>2819:R,zc}\r\njbb{s>1835:szm,x>463:R,A}\r\ntg{m<2495:lks,a<1468:dsb,a>1631:gtb,btp}\r\nlk{a<3709:R,x>2929:R,A}\r\nzts{x>3096:tp,qx}\r\nnr{m>1802:A,s>1078:A,m>995:R,R}\r\nzld{a<390:mb,m<851:dqt,rpm}\r\njbg{s<896:jzv,s<1299:kgb,klv}\r\npmb{m<1417:R,s<442:A,m<1638:A,A}\r\nlrg{s>3100:A,R}\r\ngh{a>2368:dg,s<944:nk,s>1961:bvq,mft}\r\nmr{a<2796:spl,x>2080:bs,a>3309:hqk,tr}\r\nzl{m>1278:R,x>3283:jnv,x>3194:hqp,A}\r\nfc{a<2611:A,A}\r\nxr{x>2538:tph,a>2356:hxb,x<1619:cbk,vjb}\r\nkkb{s<3362:A,m>1467:A,R}\r\ngmt{m>3392:R,m>2936:A,s>3486:A,A}\r\nnxk{s>1595:R,s>975:A,A}\r\njsx{m>3663:R,R}\r\nzm{s<708:pmb,qlr}\r\nhc{m>3256:R,m>2740:R,A}\r\ndq{x<1809:R,A}\r\nqvv{s<1183:kzp,s>1807:dhm,zh}\r\ncqz{x>1511:A,m>1524:A,s<2131:R,R}\r\ntzz{m<1978:R,A}\r\nlmn{m>2040:R,A}\r\nvkx{a<3224:A,m>2150:R,A}\r\nfqz{x>2548:svr,ntp}\r\nnxm{x<757:R,m>1111:R,s>3449:R,A}\r\nxx{x<1834:A,s>1879:R,R}\r\nmzp{s>2211:dt,m>986:dk,mnt}\r\ndgs{a<576:qrz,x<3233:kbj,a<598:xcz,nnx}\r\nmk{s<2993:A,A}\r\nxc{s>3026:xl,x>761:R,x>440:A,xtl}\r\nzxz{m<3536:A,s>2932:R,xq}\r\nzlz{s>286:A,a<2864:R,A}\r\nnb{x<286:bk,m>3457:A,m<3354:R,R}\r\nqct{m<1814:R,A}\r\nppg{m>3529:A,m>3359:A,s>2212:A,R}\r\nkfv{x<2971:jt,a>3073:gf,a<3035:mn,kt}\r\nnqc{a>3259:A,s>2625:A,s>2324:A,A}\r\nrfk{s>1484:A,x<1650:R,s>1143:R,A}\r\nvk{a<415:R,R}\r\nbg{x<1088:R,a>2982:R,a<2893:R,A}\r\nrjk{a<539:A,m<3505:A,R}\r\nscc{m<3626:A,A}\r\ncll{s>880:rph,a<2324:A,A}\r\nqcs{x>841:zld,pm}\r\ngf{x<3119:R,R}\r\nnvk{m<3199:A,a>3592:A,s>1529:R,A}\r\nfq{m<3440:R,m>3803:sz,A}\r\nsv{a>3687:R,s>2035:A,s<1816:A,R}\r\nin{a>1826:mr,ddg}\r\ncp{x>345:A,x>210:hs,m<3772:A,hjk}\r\npbv{s>235:R,R}\r\nzpj{x>2265:R,s<3244:A,A}\r\nmln{m<3479:R,m<3687:A,a<3662:A,A}\r\nxpj{a<3571:rd,x>2382:A,s<3097:A,R}\r\nsbj{s>2872:A,a>1892:R,x>3380:A,A}\r\nrx{a<2706:A,m>367:R,A}\r\ndbb{m<3265:qrv,m<3589:nb,cp}\r\nkzp{x<3650:xb,A}\r\nht{a>3452:kv,x>125:jmg,m<1365:dm,R}\r\nqx{a>539:js,a<344:fqz,m>1027:gvv,lgm}\r\nscp{x>522:dfc,a>3472:nr,tj}\r\nkhr{m<2622:R,s>773:A,A}\r\nklv{m<2327:A,A}\r\nmbd{s<2440:A,R}\r\nqb{s<2401:A,A}\r\nps{m>1593:nhh,s>1570:sbt,a>3854:nx,kvl}\r\nhqp{x<3253:R,A}\r\nfst{s>1197:A,m<650:R,R}\r\ndvf{a>763:A,A}\r\ndqk{m>2141:hdj,x<2194:qcs,s<2084:vdc,zts}\r\nxfg{s<3291:A,x<840:R,s>3387:A,R}\r\npgp{m>1354:A,m>1220:R,m<1112:R,R}\r\njnv{m<798:R,A}\r\nkmr{x<2272:A,a>2513:R,m>2758:A,R}\r\nvhl{a<410:R,s<1735:pdf,rj}\r\nlnc{x>1528:R,s<2800:R,R}\r\nmf{x>1019:nv,mdx}\r\nqrv{x>476:R,m>2800:A,A}\r\ndxp{s<2790:dtz,qd}\r\nsq{x>960:R,R}\r\nbh{s<2551:R,m<1205:R,s>3121:R,R}\r\njbk{x<3317:A,x>3747:zgc,fgj}\r\ngc{a<3555:R,m>842:R,s<843:A,lk}\r\nntp{s<3243:R,R}\r\nrd{a<3282:R,m<546:R,s>3209:R,R}\r\nxcz{x<3731:R,s<532:A,s<846:cgz,R}\r\npp{m>383:R,R}\r\nmtm{x>2210:gt,a>2632:R,x<952:R,R}\r\ngzt{x<2342:R,s<3797:A,hq}\r\nvz{s<1128:R,x<3482:R,A}\r\nzt{m>1023:R,a>3688:A,A}\r\nhx{m<1312:A,a>2992:A,A}\r\nkk{a<2501:A,a<2693:R,x>3353:A,A}\r\nxs{m<1672:R,R}\r\nnq{x<1697:zp,s<1941:qct,gld}\r\nqlv{s>3278:A,A}\r\npbg{a<3401:A,R}\r\ndfc{s>1103:A,x<656:A,a<3414:R,A}\r\npq{a<2710:R,a<2765:R,A}\r\ncfb{s>1703:R,m>1121:R,ns}\r\ngqr{x>1315:R,x>1189:R,A}\r\ndbl{a>3839:A,m>154:R,a<3802:A,R}\r\nfgj{m<3815:A,m<3908:R,R}\r\nhm{m<1831:A,s<1547:A,x>49:R,R}\r\npxr{s<424:A,R}\r\nknq{s<2710:qgl,R}\r\nfp{x<1276:R,A}\r\nvx{m<331:R,R}\r\nbdv{m>3683:R,x>1850:R,A}\r\nmft{m<3580:R,a>2109:R,m>3777:hn,rfk}\r\nthm{m<2255:R,s<372:A,A}\r\nhp{m<874:A,A}\r\nhf{x>1239:zcq,hzf}\r\nnct{s>1436:zdr,a<2108:A,A}\r\npb{x<2924:tlx,a>713:gkn,jrl}\r\npmq{x>1183:A,m<1043:A,A}\r\nszm{s>2844:R,A}\r\ngfr{a>3906:mgd,a>3878:rqg,a<3858:ps,qjg}\r\nxb{a<3398:R,a<3658:R,x>3474:A,R}\r\nlxj{s>1962:sn,x>1210:pp,a>2972:mf,skl}\r\ntqm{x<243:bx,jnq}\r\nnnx{x<3631:xxn,s<463:bd,x<3777:clp,jn}\r\nxz{m>925:R,xn}\r\nnlt{m<571:R,a<350:bvx,s>2458:A,cpc}\r\nkr{a>159:R,m<3346:R,R}\r\nrl{x>3366:fz,fv}\r\nld{a>3005:R,m>2646:R,A}\r\ncpc{a<574:R,a>672:A,A}\r\ndqt{m>361:R,hgh}\r\nlfx{x<910:A,a>1007:cqp,gbv}\r\nrph{m>689:A,m<440:R,R}\r\nsz{a>1790:R,a<1756:A,A}\r\nppd{s>1383:zps,dxj}\r\nnmc{s>3142:kvs,a<2635:A,R}\r\nkbh{m>3513:A,x<2804:R,A}\r\nfj{m<3546:A,m<3704:R,R}\r\ndjs{s<927:R,a>1245:R,x>1352:A,A}\r\npk{s<555:sg,x>2823:bxt,R}\r\nlcb{a>318:A,m<2657:A,R}\r\nlvp{s<1549:R,a<3234:A,A}\r\ndt{x>3786:R,A}\r\njvp{a<3693:R,s>1303:A,R}\r\nxp{m>1936:R,m<1784:A,R}\r\njv{x<3532:A,R}\r\nqrz{x>3194:A,m>1109:gtc,m>523:A,ntx}\r\nrqg{x>311:A,x>114:xs,nf}\r\nqjg{x>467:A,R}\r\nbgb{x>2990:A,s>3202:R,m>1998:R,R}\r\nkvb{x>658:R,s<1431:A,s>1780:A,R}\r\ncxg{x>1276:A,R}\r\ntzk{x<720:A,x>848:A,R}\r\ncgv{a>343:R,R}\r\nzsd{a<2554:xd,a>2678:sl,nmc}\r\nspz{x>308:A,mx}\r\nkrs{s>736:tm,rxf}\r\nbkh{s>992:ch,jfc}\r\nrxf{m>2865:A,a<3730:thm,R}\r\nhcg{s>2352:R,gdv}\r\nlmg{m>2174:lnj,m>2091:kvb,m>2073:R,R}\r\nfv{a<3100:R,m<2999:rxr,x>3297:cq,zb}\r\nfvs{x<1792:A,x<1941:R,x>2022:R,R}\r\ncx{a<3069:ppd,m>1830:cdb,a<3179:db,xlc}\r\nkq{s<1395:pbh,s>2575:xz,x<1600:vr,sv}\r\ngkn{m>1244:kxd,s>754:dvf,jcz}\r\nxlc{m<1399:nz,m<1647:hjh,s<1756:szh,stj}\r\ngvl{m<3550:gjl,s>939:A,x<3101:R,pxr}\r\nmz{m<3126:A,s>1525:rt,s>1337:R,bdv}\r\nbbn{x<3821:sk,s>1182:mq,hdv}\r\nsgc{x>2135:vhq,a>1340:lz,hvz}\r\nffj{s<2040:A,m<3137:A,a>3126:A,A}\r\nzb{s>788:R,R}\r\ntr{m>2296:vbt,m<998:qxr,x>1248:km,cx}\r\nqdj{x>3221:qvv,a>3251:zn,s>910:zf,ztb}\r\nxjr{m<1144:fh,s>3488:th,x<648:jd,vt}\r\ncdc{x<430:R,m<3008:R,R}\r\nrh{x>2462:pqk,pxs}\r\ndf{s>2233:A,x>532:rfg,nkz}\r\ntph{a<2207:ll,m<3325:bsv,x<3403:R,bt}\r\njs{s<2911:sdp,a>709:R,A}\r\nfgf{m>1613:A,A}\r\nhq{a>2467:A,s>3931:R,A}\r\nbhd{m<2692:A,x>2373:A,R}\r\nzdr{x>2174:R,A}\r\nrz{m<965:A,R}\r\njfc{m<3394:bg,x<1172:A,zpq}\r\nsh{a<2896:R,m<385:A,x>826:A,R}\r\ngnp{a<1557:R,m>1142:R,x<744:R,A}\r\nnk{a<2015:hmf,jq}\r\ndks{s<3214:R,R}\r\nth{s>3663:R,A}\r\ngs{m>721:A,A}\r\nlgm{m<661:R,m>791:R,x>2722:R,qrx}\r\nzcq{m>3246:A,a<3729:R,R}\r\njmg{a>3358:R,A}\r\ncj{s>3308:R,m>560:R,x>2318:A,R}\r\nbb{a<2433:pnm,x<1019:xjr,zk}\r\nbxt{a<258:A,m<770:A,a<364:R,R}\r\npg{m>209:A,x>2514:A,a>1916:A,R}\r\nlx{s<2395:A,R}\r\nfh{s<3429:sb,s>3774:A,A}\r\nfz{m<2975:R,scc}\r\npxc{s>3198:cxg,s>2946:rx,R}\r\nkm{x>1788:vqz,a<3040:cqx,mdc}\r\nddg{a>808:fb,dqk}\r\nhzf{s<2546:R,a<3800:R,A}\r\nsl{a<2751:A,a<2766:R,a>2785:R,pmz}\r\nll{s<3646:R,A}\r\ntp{s>2867:drj,s>2449:rc,x<3430:zl,mzp}\r\nnp{m>3443:A,s<1288:A,A}\r\ntlq{s>2450:R,nsh}\r\nbpd{a>2410:mtm,a>2175:cll,a<2046:cd,nct}\r\nqnx{s>642:A,R}\r\ntj{m<2578:R,R}\r\nmh{a>3677:bhd,x>2614:A,R}\r\ndmj{a<2170:A,m>1428:hh,m<1094:A,R}\r\njtx{a<254:R,x>1116:R,x<940:R,R}\r\nbl{m>3510:A,x>1826:ffp,fxx}\r\nhbx{a>2995:A,R}\r\nmsm{x<3065:mj,a<2221:cxn,x>3515:zsd,mkq}\r\nzp{a<3141:A,A}\r\nstc{a>708:R,x>2591:A,R}\r\ntm{m>3125:jv,m<2451:R,vkf}\r\ngld{a>3219:R,R}\r\nvp{x>440:A,m<1157:A,A}\r\nlpv{s>793:A,A}\r\nqfd{a>3049:R,s>954:A,A}\r\nzr{m>3468:R,m<3166:A,s<1178:A,A}\r\nstj{s<2879:hdq,x>653:sq,s<3584:A,xgx}\r\nhr{a>3762:bl,a>3690:hcg,a<3666:qs,fl}\r\nmnt{x>3744:A,s>2153:A,a>456:R,R}\r\nffq{a<3051:lrg,s<2946:A,A}\r\nlc{m<3648:R,x>864:A,A}\r\njr{a<1511:A,m>3207:A,A}\r\nkv{x<119:R,m>1521:R,s<1077:R,R}\r\ndg{a<2607:A,A}\r\ntvs{m<1456:vbg,A}\r\nlp{a>3250:xfj,jsx}\r\njfn{x>1688:A,x<1051:R,s>1033:A,djs}\r\nbj{m<2329:nsz,rzm}\r\nbpj{m>448:R,s<1134:R,A}\r\nlnv{m>1182:A,A}\r\nlks{a<1320:tvs,x<2236:xhv,fd}\r\ngmg{x<1490:R,R}\r\njq{x>1909:A,s<611:R,A}\r\nlpk{m>2259:njd,a>3441:vp,m<1079:fn,rrj}\r\nkh{s<152:rz,a<2962:zlz,a<3110:R,A}\r\ncm{a<3226:A,m<1506:R,R}\r\nstg{x<1038:R,R}\r\ncbk{x>1003:gmt,A}\r\nkxf{s>3170:A,A}\r\nlt{x<2946:R,a<2192:R,a<2411:R,rdz}\r\nnv{s<926:R,m>373:A,a>3156:A,A}\r\ntd{m>2018:zdc,R}\r\nhb{x<2787:hd,x<3294:xv,s<3246:R,R}\r\ntmz{s<789:A,fst}\r\n\r\n{x=2621,m=748,a=3275,s=2837}\r\n{x=1088,m=549,a=142,s=2751}\r\n{x=1306,m=420,a=1195,s=3}\r\n{x=475,m=985,a=1456,s=359}\r\n{x=3118,m=3737,a=426,s=180}\r\n{x=2629,m=135,a=1119,s=280}\r\n{x=1162,m=511,a=1598,s=1763}\r\n{x=335,m=231,a=1940,s=669}\r\n{x=386,m=678,a=280,s=974}\r\n{x=998,m=400,a=146,s=1416}\r\n{x=652,m=2610,a=951,s=3}\r\n{x=1735,m=1361,a=592,s=2058}\r\n{x=125,m=449,a=940,s=2999}\r\n{x=3033,m=108,a=345,s=888}\r\n{x=3099,m=929,a=320,s=465}\r\n{x=580,m=38,a=959,s=1102}\r\n{x=877,m=1638,a=2084,s=1213}\r\n{x=1787,m=285,a=2397,s=965}\r\n{x=1049,m=213,a=267,s=2642}\r\n{x=21,m=27,a=2138,s=669}\r\n{x=45,m=173,a=1716,s=2232}\r\n{x=108,m=995,a=792,s=2712}\r\n{x=1487,m=226,a=2204,s=984}\r\n{x=918,m=471,a=85,s=2089}\r\n{x=212,m=807,a=312,s=3264}\r\n{x=1428,m=2409,a=742,s=1102}\r\n{x=617,m=89,a=607,s=448}\r\n{x=112,m=468,a=141,s=1799}\r\n{x=821,m=1642,a=1733,s=314}\r\n{x=1100,m=35,a=753,s=1455}\r\n{x=1429,m=374,a=191,s=745}\r\n{x=148,m=981,a=785,s=431}\r\n{x=2143,m=333,a=638,s=428}\r\n{x=3298,m=80,a=1149,s=92}\r\n{x=500,m=103,a=1396,s=518}\r\n{x=2066,m=725,a=249,s=1074}\r\n{x=457,m=221,a=541,s=184}\r\n{x=653,m=1762,a=1048,s=197}\r\n{x=885,m=2586,a=673,s=171}\r\n{x=721,m=1604,a=2023,s=100}\r\n{x=327,m=1105,a=2837,s=27}\r\n{x=937,m=948,a=58,s=1830}\r\n{x=830,m=765,a=494,s=2536}\r\n{x=44,m=861,a=420,s=391}\r\n{x=845,m=356,a=2518,s=1018}\r\n{x=238,m=1611,a=1216,s=2089}\r\n{x=785,m=108,a=822,s=852}\r\n{x=1780,m=718,a=2276,s=1000}\r\n{x=334,m=1056,a=2009,s=239}\r\n{x=469,m=490,a=1449,s=2905}\r\n{x=3681,m=1288,a=942,s=1369}\r\n{x=601,m=217,a=343,s=2660}\r\n{x=169,m=2510,a=149,s=1150}\r\n{x=358,m=2243,a=471,s=193}\r\n{x=396,m=968,a=901,s=1878}\r\n{x=1447,m=2368,a=1064,s=199}\r\n{x=1574,m=336,a=1349,s=1770}\r\n{x=1183,m=304,a=1019,s=441}\r\n{x=387,m=1959,a=240,s=1067}\r\n{x=314,m=507,a=1344,s=2112}\r\n{x=644,m=205,a=127,s=339}\r\n{x=1197,m=479,a=1559,s=1261}\r\n{x=2182,m=656,a=1174,s=780}\r\n{x=411,m=1425,a=312,s=148}\r\n{x=858,m=123,a=502,s=388}\r\n{x=54,m=82,a=162,s=3555}\r\n{x=255,m=3087,a=282,s=106}\r\n{x=146,m=1535,a=162,s=992}\r\n{x=314,m=65,a=554,s=243}\r\n{x=2333,m=368,a=195,s=464}\r\n{x=3094,m=360,a=2674,s=137}\r\n{x=2249,m=789,a=217,s=391}\r\n{x=2458,m=1632,a=169,s=222}\r\n{x=1126,m=299,a=2031,s=3265}\r\n{x=756,m=2000,a=1762,s=1503}\r\n{x=43,m=1905,a=442,s=969}\r\n{x=1822,m=92,a=239,s=1815}\r\n{x=428,m=613,a=584,s=659}\r\n{x=966,m=82,a=9,s=132}\r\n{x=1483,m=583,a=552,s=352}\r\n{x=27,m=151,a=3528,s=3674}\r\n{x=2651,m=1753,a=11,s=2070}\r\n{x=1837,m=910,a=178,s=2018}\r\n{x=1092,m=1390,a=1419,s=2375}\r\n{x=687,m=1023,a=421,s=940}\r\n{x=2184,m=52,a=164,s=2717}\r\n{x=2836,m=586,a=669,s=1351}\r\n{x=410,m=295,a=61,s=34}\r\n{x=134,m=640,a=1092,s=1231}\r\n{x=1154,m=2666,a=147,s=2033}\r\n{x=2153,m=52,a=2865,s=2549}\r\n{x=2261,m=5,a=630,s=1894}\r\n{x=890,m=370,a=14,s=1333}\r\n{x=246,m=3492,a=560,s=2558}\r\n{x=1275,m=2566,a=624,s=2644}\r\n{x=1353,m=1826,a=208,s=2045}\r\n{x=987,m=2171,a=518,s=2096}\r\n{x=2275,m=1106,a=264,s=3166}\r\n{x=941,m=2470,a=283,s=629}\r\n{x=2106,m=1615,a=329,s=3077}\r\n{x=819,m=119,a=6,s=487}\r\n{x=2854,m=28,a=1025,s=1484}\r\n{x=357,m=1482,a=128,s=1438}\r\n{x=315,m=48,a=2182,s=457}\r\n{x=523,m=1565,a=360,s=2673}\r\n{x=547,m=906,a=319,s=795}\r\n{x=1132,m=2115,a=2356,s=1821}\r\n{x=432,m=375,a=2699,s=331}\r\n{x=652,m=1264,a=624,s=3095}\r\n{x=984,m=1957,a=2879,s=1228}\r\n{x=76,m=316,a=2360,s=2945}\r\n{x=144,m=112,a=1943,s=1574}\r\n{x=57,m=540,a=228,s=360}\r\n{x=938,m=102,a=616,s=470}\r\n{x=15,m=38,a=743,s=348}\r\n{x=43,m=1479,a=2057,s=100}\r\n{x=1266,m=671,a=329,s=74}\r\n{x=1907,m=367,a=365,s=316}\r\n{x=3405,m=281,a=39,s=76}\r\n{x=5,m=763,a=451,s=1022}\r\n{x=818,m=1960,a=1160,s=116}\r\n{x=1591,m=86,a=60,s=1100}\r\n{x=859,m=673,a=371,s=255}\r\n{x=1977,m=126,a=3036,s=747}\r\n{x=2088,m=523,a=430,s=2385}\r\n{x=278,m=1788,a=2913,s=1607}\r\n{x=818,m=1038,a=1039,s=646}\r\n{x=664,m=231,a=132,s=3540}\r\n{x=282,m=692,a=1350,s=501}\r\n{x=785,m=1826,a=138,s=1021}\r\n{x=1212,m=87,a=1171,s=311}\r\n{x=1926,m=1880,a=237,s=1081}\r\n{x=1749,m=254,a=978,s=1261}\r\n{x=374,m=797,a=1464,s=3267}\r\n{x=839,m=3048,a=3096,s=799}\r\n{x=2242,m=532,a=866,s=940}\r\n{x=825,m=174,a=1647,s=1327}\r\n{x=1,m=117,a=1925,s=351}\r\n{x=1453,m=753,a=782,s=3056}\r\n{x=1907,m=2289,a=478,s=3855}\r\n{x=1731,m=1062,a=413,s=147}\r\n{x=3224,m=114,a=764,s=254}\r\n{x=1360,m=215,a=572,s=52}\r\n{x=559,m=1236,a=1522,s=798}\r\n{x=46,m=1292,a=240,s=13}\r\n{x=1048,m=653,a=3555,s=3453}\r\n{x=871,m=2088,a=1443,s=1687}\r\n{x=790,m=322,a=2354,s=778}\r\n{x=1557,m=669,a=2836,s=1361}\r\n{x=412,m=24,a=2144,s=733}\r\n{x=40,m=1832,a=2372,s=605}\r\n{x=125,m=714,a=1265,s=328}\r\n{x=106,m=856,a=367,s=1246}\r\n{x=837,m=255,a=511,s=218}\r\n{x=248,m=1648,a=296,s=1873}\r\n{x=209,m=133,a=1828,s=87}\r\n{x=201,m=1736,a=233,s=1320}\r\n{x=510,m=531,a=1703,s=198}\r\n{x=1307,m=462,a=24,s=717}\r\n{x=1354,m=1757,a=557,s=311}\r\n{x=2561,m=2564,a=513,s=1801}\r\n{x=825,m=403,a=810,s=3178}\r\n{x=1079,m=2317,a=796,s=9}\r\n{x=272,m=83,a=1399,s=1604}\r\n{x=617,m=740,a=2087,s=1633}\r\n{x=2814,m=46,a=1245,s=327}\r\n{x=521,m=1306,a=2467,s=1860}\r\n{x=1791,m=1224,a=1079,s=847}\r\n{x=533,m=27,a=734,s=2337}\r\n{x=201,m=2727,a=208,s=1998}\r\n{x=143,m=625,a=1945,s=1468}\r\n{x=1394,m=1469,a=2576,s=45}\r\n{x=280,m=131,a=2559,s=5}\r\n{x=596,m=54,a=3237,s=378}\r\n{x=2769,m=804,a=491,s=35}\r\n{x=31,m=1355,a=1255,s=61}\r\n{x=317,m=447,a=218,s=101}\r\n{x=3447,m=760,a=1211,s=2073}\r\n{x=484,m=45,a=660,s=46}\r\n{x=2338,m=284,a=3353,s=1207}\r\n{x=1242,m=169,a=3,s=187}\r\n{x=2928,m=1528,a=412,s=976}\r\n{x=445,m=1910,a=810,s=950}\r\n{x=2341,m=272,a=2052,s=754}\r\n{x=1404,m=692,a=843,s=1382}\r\n{x=729,m=1114,a=36,s=1687}\r\n{x=1585,m=26,a=1340,s=87}\r\n{x=2188,m=651,a=1534,s=31}\r\n{x=1565,m=1779,a=840,s=810}\r\n{x=801,m=161,a=236,s=252}\r\n{x=3228,m=690,a=260,s=2421}\r\n{x=395,m=2258,a=2114,s=130}\r\n{x=1260,m=2483,a=87,s=684}\r\n{x=1584,m=1856,a=686,s=937}\r\n{x=1857,m=803,a=488,s=115}\r\n{x=781,m=23,a=412,s=8}\r\n{x=16,m=411,a=323,s=24}\r\n{x=4,m=2202,a=75,s=620}\r\n{x=1532,m=979,a=2602,s=812}\r\n{x=8,m=103,a=231,s=1810}";
    }
}
