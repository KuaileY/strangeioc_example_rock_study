﻿using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.strangerocks.ui
{
    public class StartLevelPanelView:View
    {
        [Inject]
        public IScreenUtil screenUtil { get; set; }

        public ButtonView startButton;
        public TextMesh level_field;

        public ScreenAnchor horizontalAnchor = ScreenAnchor.CENTER_HORIZONTAL;
        public ScreenAnchor verticalAnchor = ScreenAnchor.CENTER_VERTICAL;
        internal Signal proceedSignal = new Signal();
        internal void Init()
        {
            startButton.releaseSignal.AddListener(onStartClick);
            transform.localPosition = screenUtil.GetAnchorPosition(horizontalAnchor, verticalAnchor);
        }

        internal void SetLevel(int value)
        {
            level_field.text = value.ToString();
        }
        private void onStartClick()
        {
            proceedSignal.Dispatch();
        }
    }
}
