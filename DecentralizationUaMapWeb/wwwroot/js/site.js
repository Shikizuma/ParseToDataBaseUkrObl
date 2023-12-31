﻿let map;

async function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 12,
        center: { lat: 50.22152448966356, lng: 28.296777679846187 },
        mapTypeId: "terrain",
    });

    const triangleCoords = [
        {
            lat: 49.22152448966356,
            lng: 28.296777679846187
        },
        {
            lat: 49.20142984990766,
            lng: 28.27044690000446
        },
        {
            lat: 49.162336670401125,
            lng: 28.399921040423827
        },
        {
            lat: 49.133472229659716,
            lng: 28.29283579033956
        },
        {
            lat: 49.222637799994416,
            lng: 28.364675389957362
        },
        {
            lat: 49.139447610418806,
            lng: 28.269126750099513
        },
        {
            lat: 49.12178066984203,
            lng: 28.32460691008093
        },
        {
            lat: 49.157900210426455,
            lng: 28.36994213012526
        },
        {
            lat: 49.1446133998886,
            lng: 28.34054256039093
        },
        {
            lat: 49.155201419609845,
            lng: 28.38847723034001
        },
        {
            lat: 49.20723718964459,
            lng: 28.269376769722292
        },
        {
            lat: 49.13251562979249,
            lng: 28.30399542005268
        },
        {
            lat: 49.152237630062544,
            lng: 28.2617952600433
        },
        {
            lat: 49.190798687909115,
            lng: 28.43169667835911
        },
        {
            lat: 49.12514870015249,
            lng: 28.31946595988623
        },
        {
            lat: 49.123447539872124,
            lng: 28.315308139559086
        },
        {
            lat: 49.1256204800011,
            lng: 28.322529930312136
        },
        {
            lat: 49.22370765238617,
            lng: 28.368013944088382
        },
        {
            lat: 49.179213200428805,
            lng: 28.272749249878053
        },
        {
            lat: 49.13304169991454,
            lng: 28.299994839890072
        },
        {
            lat: 49.18565379958326,
            lng: 28.42840996025157
        },
        {
            lat: 49.131997450322146,
            lng: 28.337001489727037
        },
        {
            lat: 49.187662640418615,
            lng: 28.280916210115116
        },
        {
            lat: 49.22322740991708,
            lng: 28.307294719675696
        },
        {
            lat: 49.156048670010165,
            lng: 28.270770449996416
        },
        {
            lat: 49.12044729990294,
            lng: 28.332733030305207
        },
        {
            lat: 49.21992896015345,
            lng: 28.28691466028343
        },
        {
            lat: 49.152948560327786,
            lng: 28.38651984961148
        },
        {
            lat: 49.14483587957216,
            lng: 28.37316327956178
        },
        {
            lat: 49.14583519993462,
            lng: 28.371203209860393
        },
        {
            lat: 49.187373500286874,
            lng: 28.429905479754204
        },
        {
            lat: 49.14835761031545,
            lng: 28.381309569780882
        },
        {
            lat: 49.12110026976175,
            lng: 28.32753351985617
        },
        {
            lat: 49.15348505988758,
            lng: 28.265368760260195
        },
        {
            lat: 49.21804652982344,
            lng: 28.305770609825903
        },
        {
            lat: 49.15675016998438,
            lng: 28.391540150357713
        },
        {
            lat: 49.14553071017411,
            lng: 28.255073010311243
        },
        {
            lat: 49.22490265982993,
            lng: 28.327519369923117
        },
        {
            lat: 49.209607789967556,
            lng: 28.270701960327273
        },
        {
            lat: 49.20401169018737,
            lng: 28.271031079820624
        },
        {
            lat: 49.145711400160984,
            lng: 28.37628827978038
        },
        {
            lat: 49.15982045994637,
            lng: 28.396255339912074
        },
        {
            lat: 49.19326656789784,
            lng: 28.4322785181392
        },
        {
            lat: 49.13357656990284,
            lng: 28.285517880046264
        },
        {
            lat: 49.22414262028572,
            lng: 28.281120340031737
        },
        {
            lat: 49.21981481999799,
            lng: 28.298577389634943
        },
        {
            lat: 49.19606639484821,
            lng: 28.41678988124811
        },
        {
            lat: 49.1992866701437,
            lng: 28.272434220063282
        },
        {
            lat: 49.1711478402006,
            lng: 28.411769540032388
        },
        {
            lat: 49.20180410007914,
            lng: 28.399922226629545
        },
        {
            lat: 49.21074531994053,
            lng: 28.330294509584036
        },
        {
            lat: 49.23329122021367,
            lng: 28.29581229989776
        },
        {
            lat: 49.14553071017411,
            lng: 28.255073010311243
        },
        {
            lat: 49.188604511189325,
            lng: 28.433438389070506
        },
        {
            lat: 49.18187542031442,
            lng: 28.426917930118435
        },
        {
            lat: 49.22041013971613,
            lng: 28.30648639013488
        },
        {
            lat: 49.135998009800325,
            lng: 28.270913710199668
        },
        {
            lat: 49.18265002977507,
            lng: 28.285690440161794
        },
        {
            lat: 49.1640568603358,
            lng: 28.40402963006345
        },
        {
            lat: 49.141237700159785,
            lng: 28.343257459863985
        },
        {
            lat: 49.18721670978344,
            lng: 28.279977469884415
        },
        {
            lat: 49.180047710133714,
            lng: 28.423724569733245
        },
        {
            lat: 49.12598341040612,
            lng: 28.336822010227685
        },
        {
            lat: 49.19410420004886,
            lng: 28.273090580366105
        },
        {
            lat: 49.23325422030599,
            lng: 28.320715020182135
        },
        {
            lat: 49.21942627959919,
            lng: 28.31896153015056
        },
        {
            lat: 49.22242559956173,
            lng: 28.291814959992458
        },
        {
            lat: 49.23693042040268,
            lng: 28.31426553033009
        },
        {
            lat: 49.193387229936775,
            lng: 28.27562861017225
        },
        {
            lat: 49.195995739611696,
            lng: 28.272587700162312
        },
        {
            lat: 49.23386199023867,
            lng: 28.31663697961299
        },
        {
            lat: 49.122076539600585,
            lng: 28.33019681982749
        },
        {
            lat: 49.1567228395874,
            lng: 28.371805480438688
        },
        {
            lat: 49.229568310229446,
            lng: 28.3035681998127
        },
        {
            lat: 49.13418424990321,
            lng: 28.28598786035152
        },
        {
            lat: 49.21761502970992,
            lng: 28.27466157996807
        },
        {
            lat: 49.22193724970429,
            lng: 28.322768669738412
        },
        {
            lat: 49.13265644024256,
            lng: 28.3080775003764
        },
        {
            lat: 49.159565369945874,
            lng: 28.35828122999488
        },
        {
            lat: 49.15147680001435,
            lng: 28.263571910315534
        },
        {
            lat: 49.14761759957265,
            lng: 28.379004399633402
        },
        {
            lat: 49.14022811043899,
            lng: 28.34329493011702
        },
        {
            lat: 49.17748953011778,
            lng: 28.42101699973482
        },
        {
            lat: 49.224327369812336,
            lng: 28.2849986798453
        },
        {
            lat: 49.123479789560726,
            lng: 28.333921979915527
        },
        {
            lat: 49.14677271978518,
            lng: 28.34057676970231
        },
        {
            lat: 49.21782413017949,
            lng: 28.302195380212652
        },
        {
            lat: 49.1581909396602,
            lng: 28.345991360213198
        },
        {
            lat: 49.2356825903792,
            lng: 28.301001749631162
        },
        {
            lat: 49.219256859916136,
            lng: 28.30802698995371
        },
        {
            lat: 49.13355736038388,
            lng: 28.337947619687014
        },
        {
            lat: 49.12776221005788,
            lng: 28.31528064998207
        },
        {
            lat: 49.17818307019259,
            lng: 28.270563720139712
        },
        {
            lat: 49.16060901969063,
            lng: 28.282877910287375
        },
        {
            lat: 49.18248957003767,
            lng: 28.28374820041916
        },
        {
            lat: 49.235005060035554,
            lng: 28.307847850398076
        },
        {
            lat: 49.22698552026551,
            lng: 28.32991334992127
        },
        {
            lat: 49.22225287037361,
            lng: 28.270553039791107
        },
        {
            lat: 49.219504159988986,
            lng: 28.320644319979465
        },
        {
            lat: 49.23156179963731,
            lng: 28.298495189801248
        },
        {
            lat: 49.16548758998024,
            lng: 28.282112990122478
        },
        {
            lat: 49.22854803026742,
            lng: 28.330415220186346
        },
        {
            lat: 49.197954150064,
            lng: 28.270766289732546
        },
        {
            lat: 49.2132490298189,
            lng: 28.26756036042243
        },
        {
            lat: 49.15242370968643,
            lng: 28.373424330268698
        },
        {
            lat: 49.15811097014527,
            lng: 28.362570380119017
        },
        {
            lat: 49.211680306401064,
            lng: 28.380062246975218
        },
        {
            lat: 49.12162925008991,
            lng: 28.33453960012259
        },
        {
            lat: 49.154925610128814,
            lng: 28.26978056981752
        },
        {
            lat: 49.13522663969759,
            lng: 28.272492200254952
        },
        {
            lat: 49.2369889599725,
            lng: 28.30583003972459
        },
        {
            lat: 49.21057332010268,
            lng: 28.329621090041332
        },
        {
            lat: 49.15821828984223,
            lng: 28.392295499937482
        },
        {
            lat: 49.20758105712006,
            lng: 28.384465977023304
        },
        {
            lat: 49.19464491203302,
            lng: 28.419451894289573
        },
        {
            lat: 49.150510300410076,
            lng: 28.374727039621266
        },
        {
            lat: 49.19904590994081,
            lng: 28.409600545229072
        },
        {
            lat: 49.16848975000198,
            lng: 28.40958002000204
        },
        {
            lat: 49.164584239870685,
            lng: 28.279522910254208
        },
        {
            lat: 49.225328809876714,
            lng: 28.31081551962062
        },
        {
            lat: 49.23372046033107,
            lng: 28.301859190249584
        },
        {
            lat: 49.148321509729996,
            lng: 28.371735950253964
        },
        {
            lat: 49.232810639599414,
            lng: 28.319091949833698
        }
    ];

    let coordinates = await axios.get('/Home/Privacy');

    const bermudaTriangle = new google.maps.Polygon({
        paths: triangleCoords,
        strokeColor: "#FF0000",
        strokeOpacity: 0.8,
        strokeWeight: 3,
        fillColor: "#FF0000",
        fillOpacity: 0.35,
    });

    bermudaTriangle.setMap(map);
}