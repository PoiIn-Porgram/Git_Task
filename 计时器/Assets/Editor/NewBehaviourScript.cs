using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//����ͼƬ������
public class TextureChange : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        //����assetImporter(���е������ĸ���)ת��ΪTextureImporter������
        TextureImporter importer = (TextureImporter)assetImporter;
        //�����е���ͼƬ���ó� Spritre ����
        importer.textureType = TextureImporterType.Sprite;
    }
}