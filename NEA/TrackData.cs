using System;
using System.Collections.Generic;
using System.Text;

namespace NEA
{
    class SO_TrackData
    {
        public int revisionVersion { get; set; }
        public int compatibilityVersion { get; set; }
        public int difficultyRating { get; set; }
        public previewLoopBars previewLoopBars { get; set; }
        public double goBeatOffsetFromFirstNote { get; set; }
        public int difficultyType { get; set; }
        public bool isTutorial { get; set; }
        public bool isCalibration { get; set; }
        public tutorialTitleTranslation tutorialTitleTranslation { get; set; }
        public assetReference[] clipInfoAssetReferences { get; set; }
        public backgroundId backgroundId { get; set; }
        public assetReference background { get; set; }
        public assetReference groundSettingsToUse { get; set; }
        public assetReference groundSettingsOverTime { get; set; }
        public splinePathData splinePathData { get; set; }
        public splinePathData _feverTime { get; set; }
        public string[] tutorialObjects { get; set; }
        public string[] tutorialTexts { get; set; }
        public clipData[] clipDatas { get; set; }
        public List<note> notes { get; set; }
        public string[] rewindSections { get; set; }
        string lastEditedOnDate { get; set; }
    }

    class previewLoopBars
    {
        public int min { get; set; }
        public int max { get; set; }
    }
    class tutorialTitleTranslation
    {
        public string key { get; set; }
    }
    class assetReference
    {
        public string bundle { get; set; }
        public string assetName { get; set; }
        public string m_guid { get; set; }
    }
    class backgroundId
    {
        public string backgroundID { get; set; }
    }
    class splinePathData
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }
    class clipData
    {
        public int clipIndex { get; set; }
        public int startBar { get; set; }
        public int endBar { get; set; }
        public int transitionIn { get; set; }
        public int transitionInValue { get; set; }
        public int transitionInOffset { get; set; }
        public int transitionOut { get; set; }
        public int transitionOutValue { get; set; }
        public int transitionOutOffset { get; set; }
    }
    class note
    {
        public float time { get; set; }
        public int type { get; set; }
        public int colorIndex { get; set; }
        public int column { get; set; }
        public int m_size { get; set; }
    }
    class SO_ClipInfo
    {
        public timeSignatureMarker[] timeSignatureMerkers { get; set; }
        public bpmMarker[] bpmMarkers { get; set; }
        public cuePoint[] cuePoints { get; set; }
        public clipAssetReference clipAssetReference { get; set; }
    }
    class timeSignatureMarker
    {
        public int startingBeat { get; set; }
        public int ticksPerBar { get; set; }
        public int tickDivisor { get; set; }
        public int beatLengthType { get; set; }
        public int beatLengthDotted { get; set; }
    }
    class bpmMarker
    {
        public float beatLength { get; set; }
        public float clipTime { get; set; }
        public int type { get; set; }
    }
    class cuePoint
    {
        public string name { get; set; }
        public float time { get; set; }
    }
    class clipAssetReference
    {
        public string bundle { get; set; }
        public string assetName { get; set; }
        public string m_guid { get; set; }
    }
}
