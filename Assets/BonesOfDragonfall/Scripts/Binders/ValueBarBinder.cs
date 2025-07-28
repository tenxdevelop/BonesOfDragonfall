/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class ValueBarBinder : MonoBehaviour
    {
        [SerializeField] private float _lenghtBar;
        [SerializeField] private Color _upperColorBackground;
        [SerializeField] private Color _lowerColorBackground;

        [SerializeField] private RectTransform _frontValueBar;
        [SerializeField] private Image _backValueBar;
        
        private float _currentValueBar;
        private float _maxValueBar = 1;
        private Coroutine _coroutine;
        public void UpdateCurrentValueBar(float newCurrentValueBar)
        {
            var isUpper = newCurrentValueBar > _currentValueBar;
            _currentValueBar = newCurrentValueBar;
            if (isUpper)
            {
                _backValueBar.color = _upperColorBackground;
                var backRectTransform = _backValueBar.rectTransform;
                backRectTransform.sizeDelta = new Vector2(_currentValueBar / _maxValueBar * _lenghtBar, backRectTransform.sizeDelta.y);
            }
            else
            {
                _backValueBar.color = _lowerColorBackground;
                _frontValueBar.sizeDelta = new Vector2(_currentValueBar / _maxValueBar * _lenghtBar, _frontValueBar.sizeDelta.y);
            }
            
            _coroutine = StartCoroutine(UpdateValueBar(isUpper));
        }

        public void UpdateMaxValueBar(float newMaxValueBar)
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);
            
            _maxValueBar = newMaxValueBar;
            var currentLenghtBar = _currentValueBar / _maxValueBar * _lenghtBar;
            _frontValueBar.sizeDelta = new Vector2(currentLenghtBar, _frontValueBar.sizeDelta.y);
            var backRectTransform = _backValueBar.rectTransform;
            backRectTransform.sizeDelta = new Vector2(currentLenghtBar, backRectTransform.sizeDelta.y);
        }

        private IEnumerator UpdateValueBar(bool isUpper)
        {
            var currentLenghtBar = _currentValueBar / _maxValueBar * _lenghtBar;
            var precentComplete = 0f;
            RectTransform currentUpdateValueBar;

            if (isUpper)
                currentUpdateValueBar = _frontValueBar;
            else 
                currentUpdateValueBar = _backValueBar.rectTransform;
            
            while (Mathf.Abs(currentUpdateValueBar.rect.width - currentLenghtBar) > 0.1)
            {
                precentComplete += Time.deltaTime;
                var directionRectTransform = Mathf.Lerp(currentUpdateValueBar.sizeDelta.x, currentLenghtBar, precentComplete);
                currentUpdateValueBar.sizeDelta = new Vector2(directionRectTransform, currentUpdateValueBar.sizeDelta.y);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
