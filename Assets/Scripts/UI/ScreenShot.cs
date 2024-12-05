using UnityEngine;
using System.IO;
public class ScreenShot : MonoBehaviour
{
    public Camera renderCamera; // 캡처에 사용할 카메라
    public string name = "UnitImage.png"; // 저장 경로
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.dataPath, name);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Capture();
        }
    }
    void Capture()
    {
        RenderTexture rt = new RenderTexture(512, 512, 24);
        renderCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(512, 512, TextureFormat.RGBA32, false);

        renderCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 512, 512), 0, 0);
        screenShot.Apply();

        renderCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);

        Debug.Log("Captured to: " + savePath);
    }
}
