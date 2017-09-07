using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuff : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        poly1 p = new poly1();
        poly1 p2 = new poly1(7, 8);

        Debug.Log(p.x + " " + p.y);
        Debug.Log(p2.x + " " + p2.y);

        Palindrome l = new Palindrome();
        l.Main();

        int[] rand = new int[] { 3, 1, 5, 7, 4, 2, 5, 8, 0 };
        Sort(rand);
        GenerateCheckerGrid(4, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sort(int[] rand)
    {
        for (int i = 0; i < rand.Length - 1; i++)
        {
            for (int j = i + 1; j < rand.Length; j++)
            {
                if (rand[i] > rand[j])
                {
                    int a = rand[i];
                    rand[i] = rand[j];
                    rand[j] = a;
                }
            }
        }
        for (int i = 0; i < rand.Length; i++)
            Debug.Log(rand[i]);
    }

    public void GenerateCheckerGrid(int width, int height)
    {
        int[,] grid = new int[width, height];
        int color = 1;
        string s = "";
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                grid[i, j] = color;
                if (color == 1) color -= 1;
                else if (color == 0) color += 1;
            }
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                s += grid[i, j].ToString();
            }
        }
        Debug.Log(s);
    }

    void findPos(float kecepatan_x, float kecepatan_y, float waktu)
    {
        float posisi_awal_x = 0.0f;
        float posisi_awal_y = 0.0f;

        float deltaX = kecepatan_x * waktu;
        float deltaY = kecepatan_y * waktu;

        float final_pos_x = deltaX + posisi_awal_x;
        float final_pos_y = deltaX + posisi_awal_y;
        return;
    }

    void findColl(int circ_x, int circ_y) { }
}



public class Rectangle
{
    public void setWeight(int w)
    {
        weight = w;
    }
    public void setWidth(int w)
    {
        width = w;
    }
    protected int weight;
    protected int width;
}

public class Box : Rectangle
{
    public int getNumb()
    {
        return weight * width;
    }
}

public class poly1
{
    public int x, y;

    public poly1()
    {
        this.x = 2;
        this.y = 2;
    }

    public poly1(int a, int b)
    {
        this.x = a;
        this.y = b;
    }
}

public class Palindrome
{
    public bool IsPalindrome(string word)
    {
        string word_lower = word.ToLower();	//ubah kapital jadi huruf kecil
        var word_array = word_lower.ToCharArray();	//string -> char array
        int totalcheck = word_array.Length / 2 + 1;
        int maxLength = word_array.Length - 1;
        for (int i = 0; i < totalcheck; i++)
        {
            if (word_array[i] != word_array[maxLength])
            {
                return false;
            }
            maxLength -= 1;
        }
        return true;
    }

    public void Main()
    {
        Debug.Log(IsPalindrome("Deleveledt"));
    }
}

