using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class CheckListForm : Form
    {
        ///<summary>
        ///AddTextBox에 들어가는 힌트텍스트 상수
        ///</summary>
        private const string HINT_TEXT = "+ Type and Press Enter to add task.";

        /// <summary>
        /// CheckListItem의 일반 글꼴
        /// </summary>
        private Font nomalFont = new Font("맑은 고딕", 12);

        /// <summary>
        /// CheckListItem의 강조 글꼴
        /// </summary>
        private Font boldFont = new Font("맑은 고딕", 12, FontStyle.Bold);


        public CheckListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// AddTextBox가 포커스시 힌트텍스트 제거
        /// </summary>
        private void AddTextBox_Enter(object sender, EventArgs e)
        {
            if (AddTextBox.Text == HINT_TEXT)
            {
                AddTextBox.Text = "";
                AddTextBox.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// AddTextBox가 포커스를 잃었을 경우 힌트텍스트 생성
        /// </summary>
        private void AddTextBox_Leave(object sender, EventArgs e)
        {
            if (AddTextBox.Text == "")
            {
                AddTextBox.Text = HINT_TEXT;
                AddTextBox.ForeColor = Color.DimGray;
            }
        }

        /// <summary>
        /// AddTextBox에서 Enter Key 입력시 CheckListItem 생성
        /// </summary>
        private void AddTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //예정사항
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show($"{AddTextBox.Text}을(를) 추가합니다.", "예정사항", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //panel을 생성하여 배치, 데이터 뿌려주기
            }
        }

        /// <summary>
        /// CheckItem_CheckBox 클릭시 CheckListItem을 DoneList로 이동
        /// </summary>
        private void Item1_CheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Done List 로 이동시키는 메서드 작성예정
            if (Item1_CheckBox.CheckState == CheckState.Checked)
            {
                MessageBox.Show($"{Item1_Label.Text}을(를) Done으로 이동합니다.", "예정사항", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// CheckItem_Label 클릭시 InfoPanel에 CheckListItem 데이터 표시
        /// </summary>
        private void Item1_Label_MouseClick(object sender, MouseEventArgs e)
        {

            if (Info_TitleTextBox.Text != Item1_Label.Text)
            {
                //item label 강조하기
                Item1_Label.Font = boldFont;

                //info label 보여주기
                Info_DateLabel.Visible = true;
                Info_DetailLabel.Visible = true;

                //data 가져오기
                Info_TitleTextBox.Text = Item1_Label.Text;
                Info_DateTextBox.Text = DateLabel1.Text;
            }
            else
            {
                //item label 강조 제거하기
                Item1_Label.Font = nomalFont;

                //info label 감추기
                Info_DateLabel.Visible = false;
                Info_DetailLabel.Visible = false;

                //data 지우기
                Info_TitleTextBox.Text = "";
                Info_DateTextBox.Text = "";
                Info_DetailTextBox.Text = "";
            }

            //item 클릭시 X아이콘 표시
            if (Item1_Button.Visible != false)
            {
                Item1_Button.Visible = false;
            }
            else if (Item1_Button.Visible != true)
            {
                Item1_Button.Visible = true;
            }
        }

        /// <summary>
        /// CheckItem_Button 클릭시 CheckListItem을 삭제
        /// </summary>
        private void Item1_Button_MouseClick(object sender, MouseEventArgs e)
        {
            //예정사항
            MessageBox.Show($"{Item1_Label.Text}을(를) 삭제합니다.", "예정사항", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// DoneItem_Label 클릭시 InfoPanel에 DoneListItem 데이터 표시
        /// </summary>
        private void DoneItem1_Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (Info_TitleTextBox.Text != DoneItem1_Label.Text)
            {
                //item label 강조하기
                DoneItem1_Label.Font = boldFont;

                //info label 보여주기
                Info_DateLabel.Visible = true;
                Info_DetailLabel.Visible = true;

                //data 가져오기
                Info_TitleTextBox.Text = DoneItem1_Label.Text;
                Info_DateTextBox.Text = DoneLabel.Text;
            }
            else
            {
                //item label 강조 제거하기
                DoneItem1_Label.Font = nomalFont;

                //info label 감추기
                Info_DateLabel.Visible = false;
                Info_DetailLabel.Visible = false;

                //data 지우기
                Info_TitleTextBox.Text = "";
                Info_DateTextBox.Text = "";
                Info_DetailTextBox.Text = "";
            }

            //item 클릭시 X아이콘 표시
            if (DoneItem1_Button.Visible != false)
            {
                DoneItem1_Button.Visible = false;
            }
            else if (DoneItem1_Button.Visible != true)
            {
                DoneItem1_Button.Visible = true;
            }
        }

        /// <summary>
        /// DoneItem_Button 클릭시 DoneListItem을 삭제
        /// </summary>
        private void DoneItem1_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"완료된 {DoneItem1_Label.Text}을(를) 삭제하시겠습니까?.", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //예정사항
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show($"{DoneItem1_Label.Text}을(를) 삭제합니다.", "예정사항", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                MessageBox.Show($"삭제를 취소합니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Info_TextBox 더블클릭시 readonly속성 false로 변경
        /// </summary>
        private void Info_TextBox_DoubleClick(object sender, EventArgs e)
        {
            //title이 있을 때 수정가능하도록 변경
            if (Info_TitleTextBox.Text != "")
            {
                Info_TitleTextBox.ReadOnly = false;
            }
        }

        /// <summary>
        /// Info_DateTextBox 더블클릭시 readonly속성 false로 변경
        /// </summary>
        private void Info_DateTextBox_DoubleClick(object sender, EventArgs e)
        {
            //title이 있을 때 수정가능하도록 변경
            if (Info_TitleTextBox.Text != "")
            {
                Info_DateTextBox.ReadOnly = false;
            }
        }

        /// <summary>
        /// Info_DetailTextBox 더블클릭시 readonly속성 false로 변경
        /// </summary>
        private void Info_DetailTextBox_DoubleClick(object sender, EventArgs e)
        {
            //title이 있을 때 수정가능하도록 변경
            if (Info_TitleTextBox.Text != "")
            {
                Info_DetailTextBox.ReadOnly = false;
            }
        }

        /// <summary>
        /// Info_TextBox에서 Enter Key 입력시 CheckListItem의 title 변경
        /// </summary>
        private void Info_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Info_TitleTextBox.ReadOnly != true)
            {
                Item1_Label.Text = Info_TitleTextBox.Text;
            }
        }

        /// <summary>
        /// Info_TextBox에서 Enter Key 입력시 배열에서 해당 CheckListItem 칸에 데이터 저장
        /// </summary>
        private void Info_DetailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Info_DetailTextBox.ReadOnly != true)
            {
                //예정사항
                MessageBox.Show($"{Info_DetailTextBox.Text}을(를) 배열에 저장합니다.","예정사항",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
