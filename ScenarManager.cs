using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarManager : MonoBehaviour
{
    public GameObject m_StartPage;
    public GameObject m_IntroPage;
    public GameObject m_DungeonPage;
    public GameObject m_TowersPage;
    public GameObject m_TurretsPage;
    public GameObject m_PoVPage;
    public GameObject m_EndPage;

    private AudioSource m_AudioSource;
    public AudioClip m_IntroClip;
    public AudioClip m_DungeonClip;
    public AudioClip m_TowersClip;
    public AudioClip m_TurretsClip;
    public AudioClip m_EndClip;

    public AudioSource m_SuccessSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        ShowPage(m_StartPage);
    }

    #region Events
    public void YellowButton()
    {
        ShowPage(null);
        PlaySound(null);

        // Show intro page
        ShowPage(m_IntroPage);
        // Play intro
        PlaySound(m_IntroClip);
    }

    public void Success()
    {
        // Play success sound
        if (m_SuccessSource.isPlaying)
            m_SuccessSource.Stop();

        m_SuccessSource.Play();
    }

    public void DungeonComplete()
    {
        // Show towers page
        ShowPage(m_TowersPage);
        // Play towers
        PlaySound(m_TowersClip);
    }

    public void TowersComplete()
    {
        // Show turrets page
        ShowPage(m_TurretsPage);
        // Play turrets
        PlaySound(m_TurretsClip);
    }

    public void TurretsComplete()
    {
        // Show PoV page
        ShowPage(m_PoVPage);
    }

    public void PlayEnd()
    {
        // Show end
        ShowPage(m_EndPage);
        // Play end
        PlaySound(m_EndClip);
    }

    public void AllRemoved()
    {
        // Stop playing sound
        PlaySound(null);
        // Show start page
        ShowPage(m_StartPage);
    }
    #endregion

    #region Page
    private GameObject m_CurrentPage;

    private void ShowPage(GameObject _page)
    {
        if (m_CurrentPage == _page)
            return;

        if (m_CurrentPage != null)
            m_CurrentPage.SetActive(false);

        m_CurrentPage = _page;

        if (m_CurrentPage != null)
            m_CurrentPage.SetActive(true);
    }
    #endregion

    #region Sound
    private void PlaySound(AudioClip _clip)
    {
        if (m_AudioSource.isPlaying)
        {
            if (m_AudioSource.clip == _clip)
                return;
            else
                m_AudioSource.Stop();
        }

        m_AudioSource.clip = _clip;

        if (m_AudioSource.clip != null)
            m_AudioSource.Play();
    }
    #endregion

    private void Update()
    {
        if (m_CurrentPage == m_IntroPage)
        {
            if (!m_AudioSource.isPlaying)
            {
                // Show dungeon page
                ShowPage(m_DungeonPage);
                // Play dungeon
                PlaySound(m_DungeonClip);
                return;
            }
        }
    }
}