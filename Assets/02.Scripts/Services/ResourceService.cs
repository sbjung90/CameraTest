using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;
using Object = UnityEngine.Object;
public class ResourceService : Singleton<ResourceService>
{
    public SpriteAtlas _spriteAtlas;
    private bool _isInit = false;
    private int _preLoadCount;
    private Dictionary<string, GameObject> _cachedObjectDict = null;

    public bool IsInit
    {
        get => _isInit;
    }

    public override void StartService()
    {
        _cachedObjectDict = new Dictionary<string, GameObject>();
        //LocalizeService.Instance.StartService();
        //TableService.Instance.StartService();

        //_spriteAtlas = Addressables.LoadAssetAsync<SpriteAtlas>("SampleAtlas").WaitForCompletion();
    }

    private void Start()
    {
        //_preLoadCount = 0;
        //PreLoadAsset<SpriteAtlas>("SampleAtlas", (obj) =>
        //{
        //    _spriteAtlas = obj;
        //});
    }
 
    void PreLoadAsset<T>(string key, Action<T> callback = null)
    {
        _preLoadCount++;
        Addressables.LoadAssetAsync<T>(key).Completed += (obj) =>
        {

            callback?.Invoke(obj.Result);
            PreLoadEndCheck();
        };

    }

    void PreLoadEndCheck()
    {
        _preLoadCount--;
        if (_preLoadCount == 0)
        {
            _isInit = true;
        }
    }

    public Sprite GetSprite(string key)
    {
        return _spriteAtlas.GetSprite(key);
    }
    public void LoadAsset<T>(string key, Action<T> callback = null)
    {
        Addressables.LoadAssetAsync<T>(key).Completed += (obj) =>
         {

             callback?.Invoke(obj.Result);
         };

    }

    public T TableLoad<T>(string key) 
    {
        var op = Addressables.LoadAssetAsync<T>(key);
        return op.WaitForCompletion();
    }
    public Object[] TablesLoad(string key, Action<Object> callBack)
    {
        var op = Addressables.LoadAssetsAsync<Object>(key, callBack);
        return op.WaitForCompletion().ToArray();
    }

    //임시 코드
    public AudioClip LoadBGM(string key)
    {
        var op = Addressables.LoadAssetAsync<AudioClip>(key);
        return op.WaitForCompletion();
    }

    //나중에 손봐야함
    public GameObject LoadAssetCompletion<T>(string key, Action<T> callback = null, bool needCreate = false) where T : class
    {
        GameObject obj = null;

        if (!_cachedObjectDict.TryGetValue(key, out obj))
        {
            var op = Addressables.LoadAssetAsync<GameObject>(key);
            obj = op.WaitForCompletion();
            _cachedObjectDict.Add(key, obj);
        }

        if (needCreate)
            return Instantiate(obj);
        else
            return obj;
    }

    public void LoadAssets<T>(string[] keys, Action<T> callback = null)
    {
        foreach (var key in keys)
        {
            Addressables.LoadAssetAsync<T>(key).Completed += (obj) =>
            {
                callback?.Invoke(obj.Result);
            };
        }
    }

    public void LoadAssets<T>(List<string> keys, Action<T> callback = null)
    {
        foreach (var key in keys)
        {
            Addressables.LoadAssetAsync<T>(key).Completed += (obj) =>
            {
                callback?.Invoke(obj.Result);
            };

        }
    }
    public void ReleaseAsset(Object obj)
    {
        Addressables.Release(obj);
    }

    public void Instantiate(string key, Action<GameObject> callback = null)
    {
        Instantiate(key, null, callback);
    }


    public void Instantiate(string key, Transform parent, Action<GameObject> callback = null)
    {
        Addressables.InstantiateAsync(key, parent).Completed += (obj) =>
         {
             callback?.Invoke(obj.Result);
         };
    }

    public void ReleaseInstance(GameObject obj)
    {
        Addressables.ReleaseInstance(obj);
    }


}

