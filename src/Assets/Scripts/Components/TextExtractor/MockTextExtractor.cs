using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.Debug.TargetTracker;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.TextExtractor
{
    public class MockTextExtractor : ITextExtractor
    {
        public event Action<IEnumerable<string>> OnTextFound;

        public MockTextExtractor()
        {
            var debugTargetTracker = ComponentConfig.Instance.GetService<IDebugTargetTracker>();
            debugTargetTracker.OnVisibleTargetChanged += target =>
            {
                var text = GetMockText(target);
                OnTextFound?.Invoke(text);
            };
        }

        private IEnumerable<string> GetMockText(DebugImageTarget? target)
        {
            switch (target)
            {
                case DebugImageTarget.GermanNoErrors:
                    return new List<string>
                    {
                        "Anstatt immer nur zu kritisieren, legt die FPÖ",
                        "heute erstmals eine konkrete Strategie gegen",
                        "Corona vor. Sie umfasst die Punkte Küssen,",
                        "Rausgehen, Entspannen, Poltern, Ignorieren,",
                        "Erkranken, Ruhegeben, Ersticken und",
                        "Nichtimpfenneinneinnein!!!, als Eselsbrücke leicht",
                        "zu merken: „Krepieren“.",
                        "",
                        "BRAUNAU – „Herbert, mein Lieber, ich hab dich so",
                        "vermisst“, sagt Norbert Hofer und gibt dem",
                        "hustenden Herbert Kickl ein Bussi auf die Wange.",
                        "Man merkt: zwischen die beiden passt kein Blatt",
                        "Papier. Die FPÖ-Chefs führen die Tagespresse durch",
                        "das FPÖ-Labor in Braunau. Hier, in einem",
                        "Chemtrail-sicheren Bunker, wird unter der Leitung",
                        "von Dr. Sucharit Bhakdi an der „Krepieren“-",
                        "Strategie geforscht. Hofer stürmt zum neuen",
                        "Fernseher im Aufenthaltsraum. „Wer hat den da",
                        "reingebracht?“ Er schraubt ihn manisch",
                        "auseinander. „Phu! Zum Glück GIS-frei.“",
                        "",
                        "Neue Slogans",
                        "",
                        "Um die Akzeptanz für die neue Corona-Strategie zu",
                        "erhöhen, arbeitet Kickl Tag und Nacht an neuen",
                        "Slogans: „Hamdrahn statt Islam, Lunge hin statt",
                        "Muezzin, Totenbett statt Minarett, geil, heute",
                        "flutscht es wieder.“ Kickl zuckt unter mehreren",
                        "Orgasmen zusammen und lacht dabei psychopathisch,",
                        "immer wieder unterbrochen durch Hofers",
                        "Hustenanfälle.",
                        "",
                        "Gegen Impfung",
                        "",
                        "„Impfen? Ich werde sicher nichts in meinen Körper",
                        "lassen, wo ich die Inhaltsstoffe nicht kenne“,",
                        "zürnt er, ext sein Red Bull und beißt in sein 2-",
                        "Euro-Schnitzel. Auch kleine Geschenke werden auf",
                        "der Straße an die Wähler verteilt; ein blaues",
                        "Feuerzeug zum Anzünden der Gesichtsmasken ist",
                        "derzeit besonders beliebt.",
                        "",
                        "„Das erhöhte Absterben von Menschenmaterial ist",
                        "natürlich einigermaßen zu bedauern“, zeigt sich",
                        "Kickl ungewohnt mitfühlend. „Aber wir alle müssen",
                        "sterben. Sei es nächste Woche, weil wir keine",
                        "Regierungsmaulkorbjudensternmaske tragen wollen,",
                        "oder halt dann in 40 Jahren nach einem erfüllten",
                        "Leben, das macht doch keinen Unterschied.“"
                    };
                case DebugImageTarget.GermanErrors:
                    return new List<string>
                    {
                        "Österreichs Antwort auf Amazon kann sich sehen",
                        "lasen: Mit dem Kaufhaus Österreich hieven Digital-",
                        "Ministerin Margarete Schramböck und WKO-Chef",
                        "Harald „Elon“ Mahrer die Alpenrepublik ins 20.",
                        "Jahrhundert. Doch was kann die neue Plattform",
                        "wirklich? Die beiden Digital Natives laden zu",
                        "einem Rundgang ein.",
                        "",
                        "WIEN – Vor Journalisten präsentieren Mahrer und",
                        "Schramböck ihr näues Kaufhaus Österreich. „Was",
                        "diesen Trend Internetz betrifft, sind wir, wie die",
                        "Jugend sagt, oberaffengeil“, freut sich Schramböck",
                        "und dreht den Overhead-Projektor an. „Ay caramba,",
                        "turbocool oder?“, nickt Mahrer und richtet sich",
                        "seine Kangol-Mütze zulink.",
                        "",
                        "Gutscheine ab 36 EUR",
                        "„Sehen Sie das, immer, wenn ich die Hand bewege,",
                        "bewegt sich auch dieser Pfeil, das ist wegen der",
                        "sogenannten Mouse, keine Sorge, das ist keine",
                        "echte Maus. Aber ich will Sie jetzt nicht mit",
                        "digitalen Fachbegriffen langweilen“, lächelt die",
                        "Ministerin.",
                        "",
                        "Trendige Features",
                        "Die Features der Seite können sich sehen lassen.",
                        "Mit dem patentierten 17-Click®-Kauf können",
                        "Konsumenten innerhalb nur drei Stunden das",
                        "gewünschte Produkt bestellen. Kunden können",
                        "zwischen drei Zahlungsmöglichkeiten wählen: „Wir",
                        "akzeptieren Pank Austria Sofortfax,",
                        "Spendenerlagscheine und Praypal; einfach beim",
                        "Kirchgang den Betrag in den Klingelbeutel werfen“,",
                        "lächelt Mahrer. „All your Steuergeld are belong to",
                        "us!“",
                        "",
                        "Die Homepage ist laut Mahrer auch optisch auf dem",
                        "neuesten Stand: „Alle Farben, alle Schriftgrößen,",
                        "muss ich noch mehr saken?“",
                        "",
                        "Produktvielfalt",
                        "„Hier findet man alles, was man seinen Liebsten zu",
                        "Weihnachten schenken möchte“, sagt Schramböck und",
                        "klickt sich durch Hackschnitzel, Autofelgen und",
                        "Halbleiterplatten. Mahrer ist kurz unaufmerksam,",
                        "under dem Tisch scrollt er auf Amazon und sucht",
                        "nach „krokodillederschuhe swarovski kristalle",
                        "verzierung“, „känguruanus handschuhe“ und",
                        "„delfinvorhaut kontaktlinsen stahlblau“.",
                        "",
                        "Dass es keine detaillierten Suchergebnisse gibt,",
                        "ist laut Mahrer Absicht: „Wir wollten hier das",
                        "Offline-Shoppingerlebnis eins zu eins nachbilden."
                    };
                case DebugImageTarget.GermanCurseWords:
                    return new[]
                    {
                        "Genau davor diesem Scheiß wurde gewarnt! Nach dem",
                        "Heiligen Abend folgt nun die Ernüchterung. Das",
                        "Christkind wurde heute positiv auf Corona",
                        "getestet. 8,9 Millionen Menschen, die gestern",
                        "Abend noch mit ihm Kontakt hatten, müssen zehn",
                        "Tage lang in Quarantäne.",
                        "",
                        "NORDPOL / WIEN – Eine ernüchternde WhatsApp-",
                        "Nachricht versaut heute Vormittag Millionen",
                        "Österreichern die Weihnachtsstimmung: \"Hey, du",
                        "idiot, vlt hast du’s ned gemerkt aber ich war bei",
                        "dir daheim. Naja bad news haha, ich hab gestern",
                        "ned nur Geschenke gebracht. Solltest dich testen",
                        "lassen, sorry, liegrü Christkind.\"",
                        "",
                        "Symptome",
                        "Erste Symptome zeigten sich erst heute am frühen",
                        "Morgen, als das Christkind Lust bekam, zur",
                        "Entspannung Weihnachtsdeko von Interio",
                        "aufzustellen, ein Räucherstäbchen anzuzünden und",
                        "das Gabalier-Weihnachtsalbum einzulegen: \"Der",
                        "fehlende Geschmackssinn hat mich skeptisch",
                        "gemacht.\"",
                    };
                case DebugImageTarget.EnglishErrors:
                    return new[]
                    {
                        "Auspicious tidings have come our way, OGN readers.",
                        "Though plague and console shortages mark these",
                        "lands, we have heard tale of a forgotten city",
                        "beyond the endless sands, a city where the cobbled",
                        "streets are paved with PS5s, where games burst",
                        "forth from the fountains in waves like water, and",
                        "DualShock controllers hang from the crooked trees",
                        "like so many leafes.",
                        "Join us, you downcast and beaten followers of OGN,",
                        "on a journey to an eldritch land of unspeakable",
                        "gaming fortune.",
                        "Though our misbegotten realm’s console suply has",
                        "grown fallow in these merciless days, there was a",
                        "lice-ridden dotard—near insane with syphilis and",
                        "drink—who whispered of an eldritch citadel far",
                        "beyond the idle wastelands where each brick",
                        "composed of PS5 standard and digital editions.",
                        "There, mute and dumb faces peek from windows",
                        "wearing strings of DualShock controllers around",
                        "their necks as if they were mere trinkets. One can",
                        "simply dip a wicker basket in the river and emerge",
                        "with hundreds of copies of Marvel’s Spider-Man:",
                        "Miles Morales. Or so the lunatic fool told us, at",
                        "least. At first, we cast off these tales as the",
                        "ravings of starved and deranged minds, but we",
                        "could not help but dream. What if it is real,",
                        "gamers? What if?",
                        "Over the mountains that burn in the land of",
                        "eternal sun, and through the deepest canyons where",
                        "man-eating chimeras prowl every turn, that is",
                        "where we will find spires ascending to the sky",
                        "built of nothing but AMD graphics cards, solid",
                        "state hard drives, and 8-core processors. The",
                        "house of every peasant bedecked with painted",
                        "consoles, filled with overflowing chests of every",
                        "next-gen game. A friend of the drunkard—an",
                        "outdoorsman and scout by training—who came to us",
                        "with a tattered PS5 power cord claims to have seen",
                        "this Xanadu. He says that PS5s are so common that",
                        "they are used as ballast on rough-hewn fishing",
                        "junks, and the shoeless children of the poor",
                        "entertain this bizarre realm’s royalty by kicking",
                        "them around like balls. He also claims his",
                        "expedition faltered when his partners went mad",
                        "with greed and drowned trying to carry hundreds of",
                        "the Sony consoles across the raging river that",
                        "marks the boundary of this ancient land. He says",
                        "the locals reclaimed their bodies.",
                    };
                case DebugImageTarget.EnglishCurseWords:
                    return new[]
                    {
                        "EAGAN, MN—Intimidated yet intrigued as he",
                        "contemplated the thicc ass two-pound, 3,500-",
                        "calorie peppermint treat, local man Mark Carroll",
                        "confirmed Thursday he was completely fucking",
                        "overwhelmed by the logistics of eating an",
                        "oversized candy cane he had received in a holiday",
                        "gift basket. “Look at this damn thing—I mean,",
                        "where do you even start?” said Carroll, his palms",
                        "reportedly sticky and covered in plastic just from",
                        "unwrapping the enormous hooked confection, which",
                        "he reasoned was too messy to set down now but also",
                        "far too large to finish in one sitting. “I can’t",
                        "use a napkin because it’ll just stick to that. Do",
                        "I get a plate? I could cut it into pieces and eat",
                        "a little bit at a time, but a kitchen knife would",
                        "be useless on this thing. Are you supposed to",
                        "break it apart with a hammer? Oh God, now it’s in",
                        "my hair.” At press time, sources reported Carroll",
                        "was standing above a trash can and violently",
                        "shaking both hands after the candy cane had fused",
                        "tightly to his skin.",
                    };
                default:
                    return Enumerable.Empty<string>();
            }
        }
    }
}