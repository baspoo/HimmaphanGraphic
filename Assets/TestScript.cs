using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        IEnumerator fps()
        {
            while (true) 
            {
                yield return new WaitForSeconds(0.1f);
                var fps = System.Math.Round(1.0f / Time.deltaTime, 2);
                textFps.text = $"{fps} Fps\nTarget:{Application.targetFrameRate}";
            }
    
        }
        StartCoroutine(fps());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {

        }
        if (Input.GetKeyDown(KeyCode.B))
        {


        }
    }



    public void OnPlay( )
    {
        anim.enabled = true;
        StartCoroutine(re());
    }
    public void OnPause()
    {
        anim.enabled = !anim.enabled;
        textPause.color = anim.enabled ? Color.black : Color.red;
    }
    public void OnProfile()
    {
        index++;
        if (index >= profile.Count) index = 0;
        volume.profile = profile[index];
        textProfile.text = $"profile [{index}]";
    }
    public void OnRender()
    {
        render = !render;
        renders.ForEach(x => { x.SetActive(render); });
        textEff.color = render ? Color.black : Color.red;
    }
    public void OnNaree()
    {
        naree.SetActive(!naree.activeSelf);
        textNaree.color = naree.activeSelf ? Color.black : Color.red;
    }
    public void OnFilter()
    {
        volume.enabled = !volume.enabled;
        textFilter.color = volume.enabled ? Color.black : Color.red;
    }
    public void OnAnimal()
    {
        animal = !animal;
        animals.ForEach(x => { x.SetActive(animal); });
        textAnimal.color = animal ? Color.black : Color.red;
    }
    public void OnTree()
    {
        tree = !tree;
        trees.ForEach(x => { x.SetActive(tree); });
        textTree.color = tree ? Color.black : Color.red;
    }
    public void OnTerrain()
    {
        terrain.SetActive(!terrain.activeSelf);
        textTerr.color = terrain.activeSelf ? Color.black : Color.red;
    }

    bool render = true;
    bool animal = true;
    bool tree = true;
    [SerializeField] int index;
    public Animator anim;
    public UnityEngine.Rendering.Volume volume;
    public List<UnityEngine.Rendering.VolumeProfile> profile;
    public List<GameObject> renders;
    public List<GameObject> animals;
    public List<GameObject> trees;
    public GameObject naree;
    public GameObject terrain;
    public UnityEngine.UI.Text textProfile,textFps,textPause,textEff,textNaree,textTerr,textTree,textAnimal,textFilter;


    [SerializeField] GameObject root;
    IEnumerator re() {
        root.SetActive(false);
        yield return new WaitForEndOfFrame();
        root.SetActive(true);
    }

}
