using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InHwan.Util;
using InHwan.Scriptable;
using UnityEngine.SceneManagement;

namespace InHwan.Stage
{
    public class StageController : MonoBehaviour
    {
        bool m_bInit;
        Stage m_Stage;
        InputManager m_InputManager;
        ActionManager m_ActionManager;
        
        public StageState stageState; //Inspector창에서 고른 시작할 스테이지

        //Event Members
        bool m_bTouchDown;          //입력상태 처리 플래그, 유효한 블럭을 클릭한 경우 true
        BlockPos m_BlockDownPos;    //블럭 인덱스 (보드에 저장된 위치)
        Vector3 m_ClickPos;         //DOWN 위치(보드 기준 Local 좌표)

        public GameObject[] GameUI;
        public UIConfig m_UIConfig;
        public Text CntMoveText;
        public Text CntTargetText;
        public Text CntScoreText;
        public Text EndCntTargetText;

        [SerializeField] Transform m_Container;
        [SerializeField] GameObject m_CellPrefab;
        [SerializeField] GameObject m_BlockPrefab;

        void Start()
        {
            InitStage();
            
        }

        private void Update()
        {
            if (!m_bInit)
                return;

            DisPlayUI();
            OnInputHandler();
            
        }

        void InitStage()
        {
            if (m_bInit)
                return;

            m_bInit = true;
            m_InputManager = new InputManager(m_Container);
           
            BuildStage();

            //m_Stage.PrintAll();
        }

        /*
         * 스테이지를 구성한다.
         * Stage 객체를 할당받고, Stage 구성을 요청한다.
         */
        void BuildStage()
        {
            //1. Stage를 구성한다.

            switch(stageState)
            {
                case StageState.FIRST:
                    m_UIConfig.TargetBlock = Board.BlockBreed.BREED_MUN;
                    m_UIConfig.CntMove = 21;
                    m_UIConfig.CntTarget = 3;
                    break;
                case StageState.SECOND:
                    m_UIConfig.TargetBlock = Board.BlockBreed.BREED_0;
                    m_UIConfig.CntMove = 0;
                    m_UIConfig.CntTarget = 0;
                    break;
            }
            Debug.Assert(m_UIConfig.CntMove > 0 && m_UIConfig.CntTarget > 0, "The stage is not ready.");
            //CntUIConfig에 입력된 값에따라 목표 UI설정과 Stage설정
            CntMoveText.text = "" + m_UIConfig.CntMove;
            CntTargetText.text = "" + m_UIConfig.CntTarget;
            EndCntTargetText.text = CntTargetText.text;
            CntScoreText.text = "" + 0;

            //nStage : 
            m_Stage = StageBuilder.BuildStage((int)stageState);
            m_ActionManager = new ActionManager(m_Container, m_Stage, m_UIConfig, GameUI);

            //2. 생성한 stage 정보를 이용하여 씬을 구성한.
            m_Stage.ComposeStage(m_CellPrefab, m_BlockPrefab, m_Container);
        }

        void DisPlayUI()
        {
            CntMoveText.text = "" + m_UIConfig.CntMove;
            CntTargetText.text = "" + m_UIConfig.CntTarget;
            EndCntTargetText.text = CntTargetText.text;
            CntScoreText.text = "" + 0;
        }

        void OnInputHandler()
        {
            //1. Touch Down 
            if (!m_bTouchDown && m_InputManager.isTouchDown)
            {
                //1.1 보드 기준 Local 좌표를 구한다.
                Vector2 point = m_InputManager.touch2BoardPosition;

                //1.2 Play 영역(보드)에서 클릭하지 않는 경우는 무시
                if (!m_Stage.IsInsideBoard(point))
                    return;

                //1.3 클릭한 위치이 블럭을 구한다.
                BlockPos blockPos;
                if (m_Stage.IsOnValideBlock(point, out blockPos))
                {
                    //1.3.1 유효한(스와이프 가능한) 블럭에서 클릭한 경우
                    m_bTouchDown = true;        //클릭 상태 플래그 ON
                    m_BlockDownPos = blockPos;  //클릭한 블럭의 위치(row, col) 저장
                    m_ClickPos = point;         //클릭한 Local 좌표 저장
                    //Debug.Log($"Mouse Down In Board : (blockPos})");
                }
            }
            //2. Touch UP : 유효한 블럭 위에서 Down 후에만 UP 이벤트 처리
            else if (m_bTouchDown && m_InputManager.isTouchUp)
            {
                //2.1 보드 기준 Local 좌표를 구한다.
                Vector2 point = m_InputManager.touch2BoardPosition;

                //2.2 스와이프 방향을 구한다.

                m_Stage.SwipeDir = m_InputManager.EvalSwipeDir(m_ClickPos, point);

                //Debug.Log($"Swipe : {swipeDir} , Block = {m_BlockDownPos}");

                if (m_Stage.SwipeDir != Swipe.NA)
                    m_ActionManager.DoSwipeAction(m_BlockDownPos.row, m_BlockDownPos.col, m_Stage.SwipeDir);

                m_bTouchDown = false;   //클릭 상태 플래그 OFF
            }
        }

        public void ReStartGame()
        {
            SceneManager.LoadScene("PlayScene");
        }

        public void GameQuit()
        {
            Application.Quit();
        }
    }
}
