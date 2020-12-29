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
                case DebugImageTarget.Target1:
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
                case DebugImageTarget.Target2:
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
                default:
                    return Enumerable.Empty<string>();
            }
        }
    }
}