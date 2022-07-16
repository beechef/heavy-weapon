using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Player.Effects
{
    public class EffectManager : MonoBehaviour
    {
        [SerializeField] private EffectRenderer effectRendererPrefab;
        [SerializeField] private Transform effectRenderQueue;
        private readonly List<Effect> _effects = new List<Effect>();
        private readonly Dictionary<Effect, EffectRenderer> _effectRenderers = new Dictionary<Effect, EffectRenderer>();

        private void Awake()
        {
            GODictionary.AddEffectManager(gameObject, this);
            effectRenderQueue = GameObject.FindWithTag(TagName.RenderEffectQueue).transform;
        }

        private void Update()
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                Effect effect = _effects[i];
                EffectRenderer effectRenderer = _effectRenderers[effect];
                effectRenderer.Render(effect.Duration, effect.MaxDuration);
                effect.OnUpdate();
                if (!effect.IsEnd()) continue;
                effect.OnEnd();
                _effects.RemoveAt(i);
                _effectRenderers.Remove(effect);
                Destroy(effectRenderer.gameObject);
                i--;
            }
        }

        private int FindEffectByName(string effectName)
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                Effect effect = _effects[i];
                if (effect.Name().Equals(effectName)) return i;
            }

            return -1;
        }

        public void Add(Effect effect, EffectType type)
        {
            switch (type)
            {
                case EffectType.Adding:
                {
                    effect.OnStart();
                    _effects.Add(effect);
                    EffectRenderer effectRenderer = Instantiate(effectRendererPrefab, effectRenderQueue);
                    effectRenderer.icon.sprite = effect.Icon;
                    _effectRenderers.Add(effect, effectRenderer);
                    break;
                }
                case EffectType.Replace:
                {
                    int index = FindEffectByName(effect.Name());
                    if (index == -1)
                    {
                        effect.OnStart();
                        _effects.Add(effect);
                        EffectRenderer effectRenderer = Instantiate(effectRendererPrefab, effectRenderQueue);
                        effectRenderer.icon.sprite = effect.Icon;
                        _effectRenderers.Add(effect, effectRenderer);
                        break;
                    }

                    Effect oldEffect = _effects[index];

                    oldEffect.OnEnd();
                    effect.OnStart();

                    _effects.RemoveAt(index);
                    _effects.Add(effect);

                    ReplaceEffectRenderer(oldEffect, effect);

                    break;
                }
            }
        }

        private void ReplaceEffectRenderer(Effect oldEffect, Effect effect)
        {
            EffectRenderer effectRenderer = _effectRenderers[oldEffect];
            _effectRenderers.Remove(oldEffect);
            _effectRenderers.Add(effect, effectRenderer);
        }
    }

    public enum EffectType
    {
        Adding,
        Replace,
    }
}