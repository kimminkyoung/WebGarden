using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyDraw : MonoBehaviour
{
    //Pen Setting
    public Color PenColor = Color.black;
    public int PenWidth = 2;

    public bool StopDrawing = false;
    public LayerMask DrawingLayer;
    
    //이미지 설정 
    Sprite drawableSprite;
    Texture2D drawableTexture;
    Vector2 previous_drag_position;

    void Awake()
    {
        drawableSprite = GetComponent<SpriteRenderer>().sprite;
        drawableTexture = drawableSprite.texture;
    }

    // Update is called once per frame
    void Update()
    {
        bool MouseBottonDown = Input.GetMouseButtonDown(0);
        if(MouseBottonDown && !StopDrawing)
        {
            //make world position > 이미지에 레이가 부딪히는지를 보기위함
            Vector2 MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(MouseWorldPos, DrawingLayer.value);//그림을 그리는 레이어만 체크
            if(hit != null && hit.transform != null)//??
            {
                //그림그리는 함수 넣기
                PenDraw(MouseWorldPos);
            }
            else
            {

            }
        }
        else if(MouseBottonDown){
            StopDrawing = false;
        }
    }

    public void PenDraw(Vector2 worldPos)
    {
        //0618여기부분부터 시작
        //Vector2 pixelPos = 

        if (previous_drag_position == Vector2.zero)
        {
            //드래그 초기일때 픽셀에 색칠하?()
        }
        else
        {
            //아마 여기가 드래그되는길을 색칠하는거
        }
        //previous_drag_position =
    }

    public Vector2 WorldToPixelCoordinates(Vector2 worldPos)
    {
        //이미지의 좌표로 바꿈
        Vector3 localPos = transform.InverseTransformPoint(worldPos);

        //이미지의 픽셀 사이즈에맞게 좌표를 수정
        float pixelWidth = drawableSprite.rect.width;
        float pixelHeight = drawableSprite.rect.height;
        float unitToPixel = pixelWidth / drawableSprite.bounds.size.x * transform.localScale.x;
        //이게 아마 그 가로사이즈랑 스케일로 거 뭐야 좌표바꾸는거 계산용값??

        float centerX = localPos.x * unitToPixel + pixelWidth / 2;
        float centerY = localPos.y * unitToPixel + pixelHeight / 2;

        Vector2 pixelPos = new Vector2(Mathf.RoundToInt(centerX), Mathf.RoundToInt(centerY));
        return pixelPos;
    }
}
