using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // cho phép bạn gán một đối tượng Camera từ Inspector trong Unity.
    // Biến này sẽ giữ tham chiếu đến camera được sử dụng để nhìn từ góc nhìn người chơi.
    public Camera myCamera;
    //Đây là một biến riêng tư (private) dùng để lưu trữ góc quay theo trục x của nhân vật (người chơi).
    //Ban đầu, góc quay này được đặt là 0
    private float xRotation = 0f;
    // để điều chỉnh độ nhạy (sensitivity) của chuột hoặc điều khiển khi quay người chơi theo trục x
    // Giá trị càng cao thì quá trình quay người chơi càng nhanh.
    public float xSenitivity = 30f;
    public float ySenitivity = 30f;
    //nhận một tham số là Vector2 có tên "userInput". \
    //Phương thức này sẽ xử lý việc quay người chơi dựa trên thông tin đầu vào từ "userInput".
    public void ProcessLook(Vector2 userInput)
    {
        float mouseX = userInput.x;
        float mouseY = userInput.y;
        // calculate rotation for looking up and down
        //Tính toán góc quay theo trục x (nhìn lên và xuống) bằng cách trừ đi sản phẩm của "mouseY" (thông tin đầu vào quay theo trục dọc)
        //nhân với Time.deltaTime (để đảm bảo việc quay không phụ thuộc vào tốc độ khung hình) và nhân với ySenitivity (độ nhạy quay theo trục y).
        xRotation -= (mouseY * Time.deltaTime) * ySenitivity;
        //Giới hạn giá trị của "xRotation" trong khoảng từ -80 đến 80 độ. Điều này giới hạn góc quay theo trục x
        //để ngăn nhân vật quay quá lên trên hoặc quá lặn xuống.
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply to our camera transform
        myCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // rotate player to look left and right
        transform.Rotate((mouseX * Time.deltaTime) * xSenitivity * Vector3.up);

    }

}

