using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Linq;
public class Ranking : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       

        //namesAndScore["Player"] = 25;
        //print("playerscore" + namesAndScore["Player"]);
        //sortList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public MainChar main_chars;
    public Dictionary<string, int> namesAndScore = new Dictionary<string, int>()
    {
        {"3D Waffle",11},
{ "Hightower",227},
{"Papa Smurf",285},
{"57 Pixels",19},
{"Hog Butcher",279},
{"Pepper Legs",61},
{"101",233},
{"Houston",123},
{"Pinball Wizard",58},
{"Accidental Genius",69},
{"Hyper",90},
{"Pluto",292},
{"Alpha",12},
{"Jester",292},
{"Pogue",207},
{"Airport Hobo",85},
{"Jigsaw",173},
{"Prometheus",1},
{"Bearded Angler",220},
{"Joker's Grin",250},
{"Psycho Thinker",207},
{"Beetle King",153},
{"Judge",74},
{"Pusher",16},
{"Bitmap",117},
{"Junkyard Dog",143},
{"Riff Raff",142},
{"Blister",16},
{"K-9",270},
{"Roadblock",169},
{"Bowie",169},
{"Keystone",189},
{"Rooster",265},
{"Bowler",123},
{"Kickstart",239},
{"Sandbox",224},
{"Breadmaker",90},
{"Kill Switch",226},
{"Scrapper",70},
{"Broomspun",72},
{"Kingfisher",235},
{"Screwtape",156},
{"Buckshot",128},
{"Kitchen",25},
{"Sexual Chocolate",1},
{"Bugger",157},
{"Knuckles",63},
{"Shadow Chaser",255},
{"Cabbie",11},
{"Lady Killer",11},
{"Sherwood Gladiator",209},
{"Candy Butcher",134},
{"Liquid Science",196},
{"Shooter",211},
{"Capital F",143},
{"Little Cobra",104},
{"Sidewalk Enforcer",137},
{"Captain Peroxide",246},
{"Little General",100},
{"Skull Crusher",199},
{"Celtic Charger",243},
{"Lord Nikon",265},
{"Sky Bully",292},
{"Cereal Killer",155},
{"Lord Pistachio",288},
{"Slow Trot",250},
{"Chicago Blackout",289},
{"Mad Irishman",3},
{"Snake Eyes",17},
{"Chocolate Thunder",292},
{"Mad Jack",148},
{"Snow Hound",8},
{"Chuckles",140},
{"Mad Rascal",291},
{"Sofa King",191},
{"Commando",243},
{"Manimal",153},
{"Speedwell",198},
{"Cool Whip",146},
{"Marbles",274},
{"Spider Fuji",211},
{"Cosmo",185},
{"Married Man",288},
{"Springheel Jack",221},
{"Crash Override",171},
{"Marshmallow",202},
{"Squatch",299},
{"Crash Test",88},
{"Mental",138},
{"Stacker of Wheat",129},
{"Crazy Eights",210},
{"Mercury Reborn",62},
{"Sugar Man",26},
{"Criss Cross",15},
{"Midas",52},
{"Suicide Jockey",99},
{"Cross Thread",12},
{"Midnight Rambler",50},
{"Swampmasher",269},
{"Cujo",133},
{"Midnight Rider",107},
{"Swerve",240},
{"Dancing Madman",27},
{"Mindless Bobcat",194},
{"Tacklebox",275},
{"Dangle",187},
{"Mr. 44",254},
{"Take Away",35},
{"Dark Horse",168},
{"Mr. Fabulous",202},
{"Tan Stallion",235},
{"Day Hawk",207},
{"Mr. Gadget",282},
{"The China Wall",288},
{"Desert Haze",161},
{"Mr. Lucky",195},
{"The Dude",157},
{"Digger",279},
{"Mr. Peppermint",234},
{"The Flying Mouse",242},
{"Disco Thunder",145},
{"Mr. Spy",288},
{"The Happy Jock",99},
{"Disco Potato",158},
{"Mr. Thanksgiving",8},
{"The Howling Swede",95},
{"Dr. Cocktail",148},
{"Mr. Wholesome",296},
{"Thrasher",129},
{"Dredd",23},
{"Mud Pie Man",16},
{"Toe",87},
{"Dropkick",281},
{"Mule Skinner",194},
{"Toolmaker",84},
{"Drop Stone",157},
{"Murmur",281},
{"Tough Nut",68},
{"Drugstore Cowboy",219},
{"Nacho",298},
{"Trip",275},
{"Easy Sweep",206},
{"Natural Mess",14},
{"Troubadour",28},
{"Electric Player",82},
{"Necromancer",220},
{"Turnip King",183},
{"Esquire",99},
{"Neophyte Believer",160},
{"Twitch",76},
{"Fast Draw",190},
{"Nessie",291},
{"Vagabond Warrior",79},
{"Flakes",266},
{"New Cycle",88},
{"Voluntary",208},
{"Flint",287},
{"Nickname Master",213},
{"Vortex",139},
{"Freak",113},
{"Nightmare King",17},
{"Washer",289},
{"Gas Man",16},
{"Night Train",261},
{"Waylay Dave",183},
{"Glyph",81},
{"Old Man Winter",33},
{"Wheels",63},
{"Grave Digger",101},
{"Old Orange Eyes",228},
{"Wooden Man",200},
{"Guillotine",54},
{"Old Regret",130},
{"Woo Woo",247},
{"Gunhawk",235},
{"Onion King",190},
{"Yellow Menace",33},
{"High Kingdom Warrior",279},
{"Osprey",102},
{"Zero Charisma",57},
{"Highlander Monk",191},
{"Overrun",50},
{"Zesty Dragon",276},
{"Zod",76},
{"Mammoth 2",217},
{"Blinker",190},
{"FearLeSS",175},
{"Slug-em-dog",107},
{"RawSkills",41},
{"Danqqqqq",245},
{"3P-own",106},
{"VileHero",268},
{"Predator",239},
{"Freaky Ratbuster",124},
{"NeoGermal",28},
{"FireBrang",75},
{"Fatsy Bear",0},
{"HolyCombo",269},
{"ThickSKN",220},
{"Dark Matter",59},
{"BuffFreak",29},
{"HOV",63},
{"2nd Hand Joe",291},
{"ThermalMode",44},
{"Flotsams54",176},
{"Redneck Giorgio",197},
{"CodeExia",59},
{"Roadspike",159},
{"Mechani-Man",204},
{"Kazami of Truth",277},
{"Gbbledgoodk",263},
{"High Beam",53},
{"Eye Devil",86},
{"Swing Setter",206},
{"Tea Kettle",144},
{"MrOnsTr",284},
{"Wrangler Jim",225},
{"Flint Cast-Iron",2},
{"Kinged",288},
{"Lucifurious",110},
{"Lewd Dice",289},
{"RZR",260},
{"LerveDr",271},
{"Flyswat Briggs",59},
{"Legacy",14},
{"Shade Nightman",282},
{"PP Dubs",182},
{"Prone",48},
{"Hemingway Mirmillone",159},
{"Scooby Did",178},
{"Stealth",293},
{"Slinger",2},
{"Preach Man",227},
{"Unseen",181},
{"Crossing Guard",111},
{"Bad Bond",97},
{"Force",88},
{"FRMhndshk",267},
{"Easy Mac",171},
{"Sky",38},
{"SkyGod",81},
{"Toxic-oxide",252},
{"Silent",200},
{"GiddeeUP",102},
{"Irish Dze",284},
{"Apex",101},
{"DragonBlood",249},
{"Tse Tse Guy",263},
{"Shay",61},
{"IceDog",246},
{"Dallas Foxface",16},
{"Sloth",184},
{"Lounge Master",113},
{"Sprinkle Lovenuts",5},
{"Sokol",99},
{"DeathDancer",65},
{"Zorkle Sporkle",173},
{"Skool",278},
{"Pompeii Unicorn",54},
{"Noise Toy",46},
{"Flash",200},
{"Achilles Mountain",268},
{"Whip Chu",48},
{"Elektrik",152},
{"Bad Badminton",20},
{"Sly Silvermoon",82},
{"LocKz",219},
{"THRESHmSTR",179},
{"Tin Mutt",282},
{"ReiGnZ",86},
{"High-Fructose",265},
{"Sweet Bacon",152},
{"Coldy",196},
{"Sepukku",40},
{"Crazy Rox",292},
{"Beo",184},
{"Valley Guardian",286},
{"1st Degree",113},
{"Ice",183},
{"Sw00sh",104},
{"Bom Crossed",56},
{"Unleashed",247},
{"Ba1t",211},
{"Sick Saurus",43},
{"Corny",164},
{"SneakerKid",280},
{"Mad Viral",181},
{"Steel",126},
{"ShadowFax",182},
{"Clang Glyph",257},
{"Ex0tic",212},
{"Hermopolis",16},
{"xFRST",121},
{"VPR",199},
{"ManManMan",49},
{"Mosquit-No",144},
{"LyRz",260},
{"Firedog",124},
{"ELLerG!c",8},
{"Lime",6},
{"German Coach",214},
{"Hex Panther",258},
{"Energy",210},
{"Y0dler",120},
{"xSTORMx",245},
{"Blade",129},
{"WeldMaster",203},
{"Die Slice",256},
{"Tunez",193},
{"Steel Cut Toe",92},
{"Free Ham",79},
{"Truth",101},
{"Forger",171},
{"Dr. Jam Man",250},
{"Lskeee",172},
{"Black Walnut",157},
{"Seattle Jay",240},
{"Pexxious",177},
{"Journeyman",276},
{"RDTN",97},
{"Venious",38},
{"Plegasus",230},
{"Whip 2T",241},
{"Grotas",176},
{"Carrot Joker",3},
{"Skirble",67},
{"Sherm",221},
{"Switch",142},
{"Solitaire",75},
{"Gro",249},
{"Hobo Samurai",168},
{"Prof. Smirk",243},
{"Indestructible Potato",37},
{"Good William",91},
{"GuTzd",91},
{"Kamikaze Grandma",91},
{"Infinite Hole",273},
{"Are Ess Tee",185},
{"Badger the Burglar",88},
{"Sw33per",44},
{"Sir Squire",214},
{"Mauve Cactus",185},
{"Hidden Tree",0},
{"Deano",288},
{"Bruh",230},
{"AxelRoad",46},
{"Uncle Buddy",292},
{"Fadey",128},
{"Goldman",239},
{"Copilot",98},
{"Z-Boy",146},
{"Fl00d",78},
{"Bones",149},
{"DZE",295},
{"Danger Menace",141},
{"Vermilion",98},
{"Muzish",2},
{"Hang 11",217},
{"TrinitySoul",26},
{"Cooger",252},
{"Delicious Wing",286},
{"BlackExcalibur",294},
{"Kazmii",132},
{"Doz",169},
{"Risen",248},
{"AirportHobo XD",205},
{"Prez Dog",19},
{"ShadowDancer",265},
{"Cumulo",138},
{"Baked ZD",56},
{"Con Mammoth",85},
{"D-Hog-Day",105},
{"Pinball Esq",246},
{"CommandX",232},
{"Houston Rocket",289},
{"Third Moon",48},
{"Stallion Patton",225},
{"Hyper Kong",66},
{"Elder Pogue",298},
{"Rando Tank",151},
{"JesterZilla",284},
{"Lord Theus",48},
{"Omega Sub",149},
{"JigKraken",114},
{"Uncle Psycho",83},
{"Station WMD",19},
{"FrankenGrin",305},
{"Sir Shove",257},
{"Goatee Shield",124},
{"The Final Judgement",231},
{"Trash Master",199},
{"Bug Blitz",28},
{"Landfill Max",299},
{"Knight Light",75},
{"Bit Sentinel",93},
{"K-Tin Man",230},
{"Father Abbot",201},
{"Blistered Outlaw",110},
{"Scare Stone",23},
{"Admiral Tot",180},
{"RedFeet",248},
{"Chew Chew",246},
{"Scrapple",169},
{"Renegade Slugger",261},
{"Solo Kill",141},
{"Prof. Screw",145},
{"ManMaker",208},
{"RedFisher",196},
{"Trick Baron",93},
{"General Broomdog",152},
{"Automatic Slicer",247},
{"Shadow Bishop",146},
{"Raid Bucker",31},
{"Fist Wizard",105},
{"Centurion Sherman",126},
{"Atomic Blastoid",280},
{"Doz Killer",89},
{"Don Stab",8},
{"Bootleg Taximan",42},
{"Liquid Death",56},
{"Earl of Arms",72},
{"FlyGuardX",85},
{"Baby Brown",79},
{"Gov Skull",141},
{"Guncap Slingbad",176},
{"General Finish",147},
{"Sky Herald",92},
{"Pistol Hydro",146},
{"Mt. Indiana",297},
{"Lope Lope",61},
{"Greek Rifle",13},
{"Rocky Highway",182},
{"Seal Snake",270},
{"Poptart AK47",73},
{"Mad Robin",94},
{"Snow Pharaoh",221},
{"The Shield Toronto",33},
{"Jack Cassidy",53},
{"Saint La-Z-Boy",243},
{"Twix Bond",45},
{"Mad Kid",181},
{"Sultan of Speed",202},
{"Bazooka Har-de-har",107},
{"DanimalDaze",164},
{"Wolf Tribune",144},
{"Demand Chopper",61},
{"Super Flick",141},
{"B@d B0y",227},
{"Cool Law Topping",1},
{"Taz Ringer",245},
{"Frosty Squid",151},
{"Universe Bullet",125},
{"Mallow Man",66},
{"Coma Stalk",193},
{"Crash Enforcer",95},
{"Mental Prophet",224},
{"Scratch Man",76},
{"Howitzer Rise",234},
{"Iron Jesus",92},
{"Suicide Crusher",118},
{"Eight Patrol",49},
{"GoldTouch",290},
{"Troublemasher",119},
{"CosPlatoon",263},
{"Midnight Bat",23},
{"Viceswerve",90},
{"Saber-RED",0},
{"Lincoln Rider",259},
{"BoomerBox",152},
{"AlertXis",226},
{"Canine Hannibal",285},
{"Grabber",233},
{"Dance Cannon",267},
{"Darth 44",294},
{"Stud Buster",18},
{"Amphibi-Dangerous",268},
{"Mr. Alien",247},
{"Brick Mooch",39},
{"DARK HQ",117},
{"Sir Shark",19},
{"Hella Fella",13},
{"Armed Hawk",6},
{"Lucky Martian",70},
{"BuzzMouse",202},
{"Napoleonic Haze",241},
{"Tabasco Dracula",9},
{"BuzzBait",142},
{"Patton Digger",101},
{"Red Hot Kevorkian",77},
{"The Belgian",140},
{"Thunder Tank",112},
{"CZR",287},
{"DreadSherX",126},
{"Potato Sub",10},
{"JK Friend",204},
{"SubWoof330",182},
{"Dr. WMD",137},
{"Mud Finger",91},
{"Tornado Maker",200},
{"Marine Dre",184},
{"Mule Lock",107},
{"Thunder Nut",179},
{"Round Kick Boomer",293},
{"Shwatson",240},
{"Lightening Trip",174},
{"Stone Boomstick",279},
{"Grinch Cheese",12},
{"Storm Master",191},
{"Cowboy Booter",255},
{"Popeye Wipeout",287},
{"King Bass",132},
{"Insane SweepKick",129},
{"NecroBull",25},
{"Gr8 Flick",247},
{"Duke Electro",272},
{"Daffy Neo",77},
{"West Warrior",118},
{"Doughboy, Esq",24},
{"Nessie Pork",123},
{"East Army",179},
{"Fast FLAK",66},
{"New Magoo",131},
{"Rusty Vortex",151},
{"Slint FUBAR",286},
{"Master Jetson",266},
{"Sun Washer",98},
{"Hoover Spark",55},
{"King Panther",250},
{"Sly Bible",91},
{"Pyscho Hun",187},
{"Gumby Train",140},
{"Atlantic Rim",177},
{"Sapiens",43},
{"Winter Underdog",240},
{"Wooden German",121},
{"Genghis Glyph",169},
{"Sylvester Eye",148},
{"High Woo",53},
{"Grave Scuttlebutt",125},
{"Old Felix",270},
{"Low Menace",276},
{"Guillotine Trigger",148},
{"Jungle King",197},
{"Zero Corn",26},
{"Trigger Warming",272},
{"Count Eagle",72},
{"Mustard Centaur",211},
{"High Deck",22},
{"Cardinal Rebel",253},
{"Twiddle Twix",217},
{"Upper D3ckR",272},
{"Senior Smurf",121},
{"Spicy Thunder",12},
{"HighBomber",194},
{"Red Pepper",177},
{"Foot-long Fry",56},
{"360",265},
{"Sleepwalker",146},
{"Mother Hen",245},
{"Hairpin",102},
{"Clover Dragon",224},
{"Teeder",158},
{"Queen Bee",136},
{"Ladysmith",201},
{"Drift",78},
{"42nd Street",203},
{"Snapdragon",30},
{"Mother Night",207},
{"Heartbreaker",113},
{"Coffee",205},
{"The Beekeeper",272},
{"Racy Lady",48},
{"Lightweight",287},
{"Duchess",98},
{"Abiss",107},
{"Sneaky Lady",119},
{"Moxie",223},
{"Heavenly Connection",170},
{"Contrary Mary",245},
{"Tomcat",93},
{"Raggedy Ann",54},
{"Little Drunk Girl",102},
{"Eerie",45},
{"Acid Queen",297},
{"Soiled Dove",4},
{"Necessary Momentum",274},
{"Hemlock",192},
{"Cool Whipman",139},
{"Toy Town",145},
{"Roller Girl",96},
{"Loot",75},
{"Easy Street",234},
{"Alley Cat",227},
{"SolitaireQueen",83},
{"New York Mood",187},
{"Highway",96},
{"Cream",114},
{"Trash",151},
{"Romance Princess",67},
{"Low Voltage",162},
{"Emerald Goddess",207},
{"All Natural",33},
{"Spellbinder",206},
{"Nibbler",261},
{"Hoboken Nightingale",190},
{"Crumb Cake",269},
{"Treasure Devil",268},
{"Rook",197},
{"Mafia Princess",253},
{"Essex",33},
{"Backstreet",31},
{"Spitfire",99},
{"Noisy Girl",183},
{"Homerun Diva",31},
{"Curio",96},
{"Trixie",5},
{"Rope",74},
{"Magenta",275},
{"Eye Candy Kitten",79},
{"Barbwire",253},
{"Spoiler",94},
{"Nola",141},
{"Impulse",81},
{"Dahlia",24},
{"Troubled Chick",100},
{"Runway Darling",136},
{"Manly",55},
{"Feline Devil",33},
{"Bleach",14},
{"Spooky Electric",155},
{"Nutmeg",125},
{"Indigo Red",269},
{"Dandelion",180},
{"Tweety",145},
{"Santa's Little Helper",144},
{"Marshmallow Treat",90},
{"Feral Filly",239},
{"Bleachers",238},
{"Spunky Chick",200},
{"Oblivion",22},
{"Innocent Ghost",96},
{"Darkside Hooker",40},
{"Twinkle",2},
{"Saturn Extreme",261},
{"Metal Lady",224},
{"Find It Girl",187},
{"Bleeker",117},
{"Star Jammer",266},
{"Opulent Gamer",92},
{"Instant Star",149},
{"Delicious",116},
{"Undergrad",28},
{"Sassy Muffin",182},
{"Microwave",109},
{"Firecracker",134},
{"Blink",16},
{"Star Killer",292},
{"Palomino",172},
{"Intimidating Presence",30},
{"Digital Goddess",159},
{"Video Game Heroine",171},
{"Scratch",47},
{"Mirage",77},
{"Firefly",280},
{"Bliss",84},
{"Steel Heart",29},
{"Peanut Butter Woman",272},
{"Iron Butterfly",199},
{"Delirium",41},
{"Vixen",97},
{"Scuffs",111},
{"Miss Fix It",17},
{"Flashpoint",71},
{"Boost",30},
{"Stickers",216},
{"Pepper",130},
{"Jade Fox",34},
{"Demo",242},
{"Voodoo Queen",61},
{"Serendipity",99},
{"Miss Lucky",28},
{"Freesia",56},
{"Burn",68},
{"Stick Shift",134},
{"Petite Beauty",150},
{"Jersey",117},
{"Demolition Queen",292},
{"Whipsaw",97},
{"Shady Lady",114},
{"Miss Murder",270},
{"Frenzy",266},
{"Call Back Queen",8},
{"Succubus In Training",35},
{"Pink Nightmare",174},
{"Kabuki",280},
{"Despair",119},
{"Whistler",122},
{"Shamrock",196},
{"Miss Mustard",26},
{"Frosty",136},
{"Campfire Mama",37},
{"Sugar Hiccup",94},
{"Pinup Diva",147},
{"Kamikaze Granny",212},
{"Devine Melon",277},
{"White Swan",33},
{"Shivers",174},
{"Moon Cricket",296},
{"Fuzzy Logic Hottie",259},
{"Canary Apple Red",293},
{"Sun Runner",237},
{"Pitfall",71},
{"Kimono Goddess",1},
{"Dewdrop Doll",291},
{"Wiccan Trouble",155},
{"Show Off",171},
{"Moonflower",176},
{"Gentle Avenger",101},
{"Chameleon",247},
{"Sweetness",126},
{"Pixie",124},
{"Ladybird",167},
{"Dez",189},
{"Wildcat Talent",91},
{"Silver Cup",23},
{"Moon Orchid",114},
{"Golden Cougar",61},
{"Chapstick",23},
{"Swedish Pixie",284},
{"Pockets",206},
{"Lady Fantastic",145},
{"Domino",18},
{"Wild Hair",55},
{"Skylark",55},
{"Morbid Angel",24},
{"Gothic Slacker",179},
{"Charms",172},
{"Tall Sally",192},
{"Proper",226},
{"Lady In Red",254},
{"Dora the Destroyer",235},
{"Winded On Friday",78},
{"Sleek Assassin",278},
{"Most Wanted",212},
{"Granola",99},
{"Classy Dancer",98},
{"Tangerine",294},
{"Purity",237},
{"Lady Pomegranate",218},
{"Dream Killer",21},
{"Wings",39},
{"Woodland Beauty",61},
{"180",92},
{"Uluru Walker",259},
{"Hen Skittle",88},
{"Bad Beret",254},
{"Clover Rabbit",207},
{"TeederSmartie",183},
{"Mantis Queen",173},
{"Evil Smith",144},
{"BearDrift",51},
{"21st Street",57},
{"White Dragon",4},
{"NightWonka",188},
{"ManBreaker",33},
{"Cinder Coffee",71},
{"Pop Bee",225},
{"Racy Babe",233},
{"Ella of Light",22},
{"Taffy Duchess",149},
{"Abyss Tamer",37},
{"Lady Katniss",263},
{"Pixy Mox",159},
{"Heaven Sent",57},
{"Scarlet Mary",290},
{"9Lives",122},
{"DollFaceKillah",267},
{"Little Granger",152},
{"Double Eerie",15},
{"Acetic Princess",176},
{"Princess Dove",24},
{"Jelly Momentum",143},
{"Po1son",238},
{"Bridge Whip",144},
{"Toy Peep",36},
{"Rink Ruler",274},
{"Poppin Loot",69},
{"Street Jolly",224},
{"NightDream",272},
{"Dorothy Solitaire",4},
{"New York Sixlet",228},
{"Freeway",244},
{"Juno Cream",277},
{"Trash Pocky",163},
{"Bad Princess",112},
{"Mrs. Voltage",46},
{"Emerald Vine",229},
{"M8deUp",69},
{"Baby Spell",277},
{"Burst Nibbler",9},
{"Phoenix Sparrow",26},
{"ZenaCake",10},
{"Minty Devil",140},
{"Fire Queen",268},
{"Mafia Rapunzel",35},
{"Twix Esses",179},
{"Alley Fiend",269},
{"Spit Turanga",35},
{"NoiseCake",280},
{"Knock Out Star",17},
{"Killer Curio",256},
{"Trixie Doodle",97},
{"Twine X",128},
{"Bat Magenta",194},
{"Thumb Candy",116},
{"RZRWRE",269},
{"Spoiler Betty",136},
{"Apple Nola",131},
{"SprkR",296},
{"Gold Dahlia",213},
{"Troubled Pie",146},
{"Bad Beh8vior",157},
{"Manly Reno",105},
{"Devil Bread",45},
{"Chlorine",43},
{"Jo Jo Spooky",198},
{"Biscuit Meg",200},
{"Black Hole Necromancer",256},
{"Gabriel Dandelion",295},
{"Tweety Bun Bun",58},
{"Blood Taker",104},
{"Ozzie Treat",120},
{"Feral Cookie",114},
{"Ember Master",184},
{"Spunky Sphinx",257},
{"Pecan Oblivion",100},
{"Nice Gnome",197},
{"Darkside Isis",215},
{"Twinkle Cocoa",198},
{"VenusXX",174},
{"Metal Aphrodite",85},
{"Girl Brownie",178},
{"MeeP",126},
{"Athena Star",65},
{"Gamer Bean",215},
{"RightN0w2",89},
{"Delicious Cupid",81},
{"Undergrad Split",24},
{"Fire Sass",117},
{"Microwave Chardonnay",260},
{"Short Firecracker",100},
{"Engine Eye",115},
{"Killer Merlot",117},
{"Palomino Cake",7},
{"Intimidation Station",234},
{"Digital Moonshine",273},
{"Red Heroine",192},
{"Freeze Queen",113},
{"Bourbon Mirage",68},
{"Firefly Caramel",229},
{"Saturnalia",232},
{"Steel Ginger",140},
{"Gingersnap Woman",253},
{"Titanium Ladybug",284},
{"Soda Delirium",126},
{"S???more Vixen",102},
{"Cuff Queen",99},
{"Miss Rum Punch",53},
{"Flash Protein",105},
{"Boost Princess",168},
{"Rummy Stickers",216},
{"Fresh Peper",167},
{"Tin Fox",220},
{"Demo Tequila",254},
{"Tart Voodoo",51},
{"Spontan8ty",175},
{"Lucky Brandy",258},
{"Twisty Freesia",141},
{"Dark Burn",292},
{"Barbera Shift",7},
{"Juice Petite",218},
{"Alberta",212},
{"Queen Ginger",165},
{"Combo Saw",264},
{"Shadow Gal",110},
{"Murder Cherry",97},
{"Hitch Frenzy",149},
{"Referee",160},
{"Berry Succubus",31},
{"Pink C",37},
{"Noh Noh",219},
{"Blue Despair",179},
{"Snapple Whistler",214},
{"Shimmy Shammy",7},
{"Black Mustard",94},
{"Frosty Snazz",225},
{"Lumberyard",56},
{"Sugar Apple",1},
{"Aqua Diva",239},
{"Lil Rebel Ma",36},
{"Divine Bramble",214},
{"Swan Mustang",168},
{"Shy Warrior",263},
{"Moon Peaches",50},
{"Fuzzy Claws",208},
{"Red Delicious",278},
{"Sun Lemon",187},
{"Pitfall Whiskers",93},
{"High Heel Goddess",234},
{"Doll Champagne",142},
{"Trouble Mittens",251},
{"Show Boat",214},
{"Martini Flower",124},
{"Avenge Paws",29},
{"Cricket",289},
{"Sweet Manhattan",173},
{"Snout Pixie",250},
{"Pigeon Woman",127},
{"Dez Bonbon",128},
{"Wildcat Appaloosa",135},
{"Silver Agent",114},
{"Plum Moon",247},
{"Cougar Fuzz",164},
{"Alias Stick",253},
{"Swedish Twizz",197},
{"Pocket Muzzie",10},
{"Lady Peach",298},
{"Sugar Domino",58},
{"Wild Kitten",83},
{"Sky Trinity",93},
{"Morbid Sugar",59},
{"Slacker Cat",296},
{"Venom Charms",27},
{"Tall Honey",122},
{"Pepper Mouse",104},
{"Red Woman",134},
{"Maple Destroyer",25},
{"Friday Fox",254},
{"Sleek Zelda",116},
{"Wanted Candy",177},
{"Granola Dove",221},
{"Classy Luck",11},
{"Plenty Orange",262},
{"Purity Catnip",14},
{"Wonder Lady",80},
{"Tootsie Killer",201},
{"Bambi Wings",219},
{"HedgeH0g2",48},
{"ButterQuest",296},
{"Skittle Mine",2},
{"Bad Bunny",193},
{"Willow Dragon",83},
{"SmartieQuest",1},
{"Chip Queen",10},
{"Reed Lady",96},
{"DriftDetector",43},
{"Street Squirrel",192},
{"White Snare",200},
{"Night Magnet",288},
{"RoarSweetie",135},
{"Poppy Coffee",67},
{"Polar Bee",101},
{"Racy Lion",274},
{"Light Lion",119},
{"Subzero Taffy",113},
{"Chasm Face",60},
{"Mint Ness",18},
{"Pixie Soldier",58},
{"DuckDuck",144},
{"Mum Mary",96},
{"LifeRobber",111},
{"Killah Goose",271},
{"Daffy Girl",253},
{"Eerie Mizzen",232},
{"Acid Gosling",273},
{"Fennel Dove",279},
{"Jelly Camber",280},
{"Arsenic Coo",191},
{"Cool Iris",264},
{"Toy Dogwatch",275},
{"Roller Turtle",49},
{"Marigold Loot",52},
{"Vicious Street",99},
{"Alley Frog",76},
{"Moon Solitaire",284},
{"New York Winder",111},
{"Gullyway",254},
{"Snow Cream",264},
{"Trash Sling",20},
{"Romance Guppy",44},
{"SunVolt",266},
{"Green Scavenger",80},
{"Natural Gold",25},
{"SpellTansy",79},
{"Lava Nibbler",132},
{"Phoenix Tetra",208},
{"TulipCake",1},
{"Devil Blade",243},
{"Fire Fish",72},
{"Sienna Princess",10},
{"Twin Blaze",153},
{"Back Bett",231},
{"Bug Fire",78},
{"NoiseFire",74},
{"Koi Diva",270},
{"Widow Curio",257},
{"TrixiePhany",289},
{"Ember Rope",210},
{"Pink Hopper",27},
{"BlacKitten",38},
{"Congo Wire",178},
{"Betty Cricket",86},
{"Club Nola",138},
{"Impulsive Flower",139},
{"Dahlia Bumble",290},
{"Devil Chick",290},
{"Darling Peacock",195},
{"Reno Monarch",41},
{"Fire Feline",41},
{"Flame OUT",11},
{"Spooky Yellowjacket",43},
{"Nutmeg Riot",22},
{"RedMouth",14},
{"VenusLion",292},
{"NemesisX",81},
{"BloodEater",97},
{"Lunar Treat",84},
{"Feral Mayhem",32},
{"Terror Master",58},
{"Spunky Comet",148},
{"Fiend Oblivion",68},
{"Green Ghost",222},
{"Darkside Orbit",152},
{"Twinkle Cutlass",184},
{"Electric Saturn",76},
{"Metal Star",185},
{"Pearl Girl",128},
{"CoB@lt",285},
{"LunaStar",262},
{"Diamond Gamer",221},
{"Star Sword",272},
{"Cupid Dust",235},
{"Winter Bite",223},
{"Sass Burst",194},
{"MicroStar",178},
{"Fire Bite",23},
{"Mud Eye",227},
{"Starshine",84},
{"StormCake",90},
{"Cosmic Presence",76},
{"Digital Equinox",241},
{"Twister Hero",93},
{"Star Scratch",159},
{"RetroMirage",293},
{"Black Firefly",168},
{"Dakota Bliss",221},
{"Steel Solstice",191},
{"Blackfire",8},
{"Texas Butterfly",37},
{"Delirious Supernova",50},
{"Blizzard Vixen",131},
{"Geneva Cuffs",233},
{"Miss Twilight",159},
{"CirrusFlash",244},
{"Paris Boost",114},
{"StarZen",241},
{"PepperBurst",3},
{"London Fox",225},
{"Demo Zero",291},
{"Voodoo Cyclone",119},
{"Tokyo Dream",55},
{"Lucky Aurora",112},
{"Twisty Dew",226},
{"Dallas Burn",179},
{"Bang Shift",204},
{"Petite Flurry",106},
{"Nueva Nova",4},
{"Ginger Chaos",118},
{"Ship Whip",103},
{"Shady Prairie",161},
{"Murder Matter",102},
{"CloudFrenzy",116},
{"Milan Call Back",189},
{"FireBerry",137},
{"Pink Stream",90},
{"Roma Kabuki",35},
{"Light Despair",277},
{"SunnySnap",23},
{"Austin Shamrock",244},
{"Miss Nova",185},
{"Frosty Sunshine",71},
{"Athens Fire",117},
{"Parallax Sugar",72},
{"Aqua Monsoon",171},
{"Berlin Kamikaze",46},
{"Divine Quasar",94},
{"Breezy Mustang",239},
{"Bombay Shivers",174},
{"Virgo Moon",270},
{"Fuzzy Rainbow",25},
{"Kawaii Red",199},
{"Sun Leo",195},
{"Sand Whiskers",78},
{"California Goddess",4},
{"X-Dew",48},
{"Wiccan Thunder",0},
{"Cali Yacht",79},
{"Moon Radar",14},
{"Icy Avenger",83},
{"Lilac Lizard",209},
{"True Sweetness",222},
{"Snowflake Pixie",6},
{"Rosie Bird",72},
{"Dez North",111},
{"Jetta Talent",128},
{"Silver Rose",273},
{"Moon Laser",26},
{"Gold Bentley",169},
{"Daisy Stick",218},
{"Pixie Taze",190},
{"Pocket Mazda",233},
{"Black Fantastic",241},
{"Domino Combat",45},
{"Wild Tesla",53},
{"Sky Dahlia",32},
{"FLAK Angel",164},
{"Gothic Gucci",48},
{"Venom Petunia",277},
{"SWAT Honey",163},
{"Pepper Prada",157},
{"Lady Petal",138},
{"Helmet Destroyer",2},
{"Friday Ferrari",3},
{"Leaf Assassin",288},
{"Kevlar Wanted",206},
{"Dove Dolce",160},
{"Dance Bloom",5},
{"Orange Teflon",65},
{"Versace-Cat",47},
{"Lady Q",57},
{"Killer Grenade",193},
{"Bambi Benz",60},
{ "Player",0 }
    };
    public List<Sprite> RandomImage = new List<Sprite>();
    public Image flag1;
    public Image flag2;
    public Image flag3;
    public Image flag4;
    public TextMeshProUGUI rankOrder1;
    public TextMeshProUGUI rankOrder2;
    public TextMeshProUGUI rankOrder3;
    public TextMeshProUGUI rankOrder4;
    public TextMeshProUGUI rankOrder5;
    public TextMeshProUGUI rankOrderKeys1;
    public TextMeshProUGUI rankOrderKeys2;
    public TextMeshProUGUI rankOrderKeys3;
    public TextMeshProUGUI rankOrderKeys4;
    public TextMeshProUGUI rankOrderKeys5;
    public TextMeshProUGUI rankOrderValues1;
    public TextMeshProUGUI rankOrderValues2;
    public TextMeshProUGUI rankOrderValues3;
    public TextMeshProUGUI rankOrderValues4;
    public TextMeshProUGUI rankOrderValues5;

    public GameObject koyuBlue;
    public GameObject Blue1;
    public GameObject Blue2;
    public void sortList()
    {
        
        namesAndScore["Player"] = PlayerPrefs.GetInt("IhaveScore");
        var items = from pair in namesAndScore orderby pair.Value descending select pair;
        var sortLists = items.ToList();
        var place = 0;
        var place1 = 0;
        var place2 = 0;
        var place3 = 0;
        var place4 = 0;
        
        

        // Display results.
        foreach (var item in sortLists)
        {
            
            
            if (item.Key == "Player")
            {
                place = sortLists.IndexOf(item);

                print(place);
                if (place == 0)
                {
                    koyuBlue.transform.localPosition = new Vector3(0, 150, 0);
                    Blue1.transform.localPosition = new Vector3(0, -50, 0);
                    place = sortLists.IndexOf(item);
                    place1 = sortLists.IndexOf(item) + 1;
                    place2 = sortLists.IndexOf(item) + 2;
                    place3 = sortLists.IndexOf(item) + 3;
                    place4 = sortLists.IndexOf(item) + 4;
                    flag1.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag2.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag3.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag4.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];

                    rankOrderKeys1.text = "" + sortLists[place2].Key;
                    rankOrderKeys2.text = "" + sortLists[place1].Key;
                    rankOrderKeys3.text = "" + sortLists[place].Key;
                    rankOrderKeys4.text = "" + sortLists[place3].Key;
                    rankOrderKeys5.text = "" + sortLists[place4].Key;
                    rankOrderValues1.text = "" + sortLists[place2].Value;
                    rankOrderValues2.text = "" + sortLists[place1].Value;
                    rankOrderValues3.text = "" + sortLists[place].Value;
                    rankOrderValues4.text = "" + sortLists[place3].Value;
                    rankOrderValues5.text = "" + sortLists[place4].Value;
                    rankOrder1.text = "" + place2;
                    rankOrder2.text = "" + place1;
                    rankOrder3.text = "" + (place+1);
                    rankOrder4.text = "" + place3;
                    rankOrder5.text = "" + place4;
                    print(place2 + sortLists[place2].Key);
                    print(place1 + sortLists[place1].Key);
                    print(place + sortLists[place].Key);
                    print(place3 + sortLists[place3].Key);
                    print(place4 + sortLists[place4].Key);
                    break;
                }
                else if (place == 1)
                {
                    koyuBlue.transform.localPosition = new Vector3(0, 150, 0);
                    Blue2.transform.localPosition = new Vector3(0, -50, 0);
                    place1 = sortLists.IndexOf(item) + 1;
                    place = sortLists.IndexOf(item);
                    
                    place2 = sortLists.IndexOf(item) +1;
                    place3 = sortLists.IndexOf(item) + 2;
                    place4 = sortLists.IndexOf(item) + 3;
                    flag1.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag2.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag3.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag4.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];

                    rankOrderKeys1.text = "" + sortLists[place4].Key;
                    rankOrderKeys2.text = "" + sortLists[place3].Key;
                    rankOrderKeys3.text = "" + sortLists[place].Key;
                    rankOrderKeys4.text = "" + sortLists[place1].Key;
                    rankOrderKeys5.text = "" + sortLists[place2].Key;
                    rankOrderValues1.text = "" + sortLists[place4].Value;
                    rankOrderValues2.text = "" + sortLists[place3].Value;
                    rankOrderValues3.text = "" + sortLists[place].Value;
                    rankOrderValues4.text = "" + sortLists[place1].Value;
                    rankOrderValues5.text = "" + sortLists[place2].Value;
                    rankOrder1.text = "" + place4;
                    rankOrder2.text = "" + place3;
                    rankOrder3.text = "" + place;
                    rankOrder4.text = "" + place1;
                    rankOrder5.text = "" + place2;
                    print(place2 + sortLists[place2].Key);
                    print(place1 + sortLists[place1].Key);
                    print(place + sortLists[place].Key);
                    print(place3 + sortLists[place3].Key);
                    print(place4 + sortLists[place4].Key);
                    break;
                }
                else
                {
                    place = sortLists.IndexOf(item);
                    place1 = sortLists.IndexOf(item) + 1;
                    place2 = sortLists.IndexOf(item) + 2;
                    place3 = sortLists.IndexOf(item) - 1;
                    place4 = sortLists.IndexOf(item) - 2;
                    flag1.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag2.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag3.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];
                    flag4.sprite = RandomImage[UnityEngine.Random.Range(0, 6)];

                    rankOrderKeys1.text = "" + sortLists[place4].Key;
                    rankOrderKeys2.text = "" + sortLists[place3].Key;
                    rankOrderKeys3.text = "" + sortLists[place].Key;
                    rankOrderKeys4.text = "" + sortLists[place1].Key;
                    rankOrderKeys5.text = "" + sortLists[place2].Key;
                    rankOrderValues1.text = "" + sortLists[place4].Value;
                    rankOrderValues2.text = "" + sortLists[place3].Value;
                    rankOrderValues3.text = "" + sortLists[place].Value;
                    rankOrderValues4.text = "" + sortLists[place1].Value;
                    rankOrderValues5.text = "" + sortLists[place2].Value;
                    rankOrder1.text = "" + place4;
                    rankOrder2.text = "" + place3;
                    rankOrder3.text = "" + place;
                    rankOrder4.text = "" + place1;
                    rankOrder5.text = "" + place2;
                    print(place2 + sortLists[place2].Key);
                    print(place1 + sortLists[place1].Key);
                    print(place + sortLists[place].Key);
                    print(place3 + sortLists[place3].Key);
                    print(place4 + sortLists[place4].Key);
                    break;
                }

                
            }
        }

    }
}
