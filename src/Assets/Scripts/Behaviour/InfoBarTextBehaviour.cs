﻿using Assets.Scripts;
using Assets.Scripts.Components.CurseWordChecker;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarTextBehaviour : MonoBehaviour
{
    public Font infoBarFont;

    private const string MistakesInfoTextTemplate = "Mistakes: {0} (minor) / {1} (fatal)";
    private const string CWBInfoTextTemplate = "Bleeped Curse Words: {0}";

    private (GameObject GO, Text Text)? mistakesInfoText;
    private (GameObject GO, Text Text)? cwbInfoText;

    public void Start()
    {
        var settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
        var spellChecker = ComponentConfig.Instance.GetService<ISpellChecker>();
        var curseWordChecker = ComponentConfig.Instance.GetService<ICurseWordChecker>();

        spellChecker.OnMistakesFound +=
            mistakes =>
            {
                this.UpdateSpellingMistakeInfoText(mistakes);
                this.RealignInfoTexts();
            };

        curseWordChecker.OnCurseWordsFound +=
            curseWords =>
            {
                this.UpdateCurseWordInfoText(curseWords);
                this.RealignInfoTexts();
            };

        settingsComponent.OnIsCWBEnabledChanged +=
            isCwbEnabled =>
            {
                if (this.cwbInfoText != null)
                {
                    this.cwbInfoText.Value.GO.SetActive(isCwbEnabled);
                }

                this.RealignInfoTexts();
            };
    }

    private void UpdateSpellingMistakeInfoText(IEnumerable<SpellingMistake> mistakes)
    {
        if (this.mistakesInfoText == null)
        {
            var gameObject = new GameObject("Mistakes InfoText");
            gameObject.transform.SetParent(this.transform);
            gameObject.transform.position = this.transform.position;
            gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            gameObject.transform.localScale = new Vector3(1f, 0.02f, 1f);

            var text = gameObject.AddComponent<Text>();
            text.font = this.infoBarFont;
            text.fontSize = 85;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.alignment = TextAnchor.MiddleCenter;

            this.mistakesInfoText = (gameObject, text);
        }

        this.mistakesInfoText.Value.Text.text = string.Format(
            MistakesInfoTextTemplate,
            mistakes.Count(m => m.Severity == SpellingSeverity.Minor),
            mistakes.Count(m => m.Severity == SpellingSeverity.Fatal));
    }

    private void UpdateCurseWordInfoText(IEnumerable<CurseWord> curseWords)
    {
        if (this.cwbInfoText == null)
        {
            var gameObject = new GameObject("CWB InfoText");
            gameObject.AddComponent<Renderer>();

            gameObject.transform.SetParent(this.transform);
            gameObject.transform.position = this.transform.position;
            gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            gameObject.transform.localScale = new Vector3(1f, 0.02f, 1f);

            var text = gameObject.AddComponent<Text>();
            text.font = this.infoBarFont;
            text.fontSize = 85;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.alignment = TextAnchor.MiddleCenter;

            this.cwbInfoText = (gameObject, text);
        }

        this.cwbInfoText.Value.Text.text = string.Format(
            CWBInfoTextTemplate,
            curseWords.Count());
    }

    private void RealignInfoTexts()
    {
        if (this.cwbInfoText.HasValue
            && this.cwbInfoText.Value.GO.activeSelf)
        {
            if (this.mistakesInfoText.HasValue)
            {
                this.mistakesInfoText.Value.GO.transform.localPosition = new Vector3(0f, 0f, 1.25f);
                this.cwbInfoText.Value.GO.transform.localPosition = new Vector3(0f, 0f, -1.25f);
            }
            else
            {
                this.cwbInfoText.Value.GO.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
        else
        {
            if (this.mistakesInfoText.HasValue)
            {
                this.mistakesInfoText.Value.GO.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
    }
}