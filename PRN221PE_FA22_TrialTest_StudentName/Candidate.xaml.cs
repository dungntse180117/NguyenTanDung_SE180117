using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using businessObject.Models;
using repos;
using Services;

namespace PRN221PE_FA22_TrialTest_StudentName_
{
    /// <summary>
    /// Interaction logic for Candidate.xaml
    /// </summary>
    public partial class Candidate : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly int? roleID;
        public Candidate()
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobService = new JobPostingService();
            this.roleID = roleID;
        }

        private void LoadDataInit()
        {
            this.dataProfile.ItemsSource = profileService.GetCandidates();
            this.cmbJobPosting.ItemsSource = jobService.GetJobPostings();
            this.cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            this.cmbJobPosting.SelectedValuePath = "PostingId";
        }

       
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtName.Text;
            candidateProfile.Birthday = DateTime.Parse(birthDate.Text);
            candidateProfile.ProfileUrl = txtURL.Text;
            candidateProfile.ProfileShortDescription = txtDes.Text;
            candidateProfile.PostingId = cmbJobPosting.SelectedValue.ToString();
            if (profileService.AddCandidateProfile(candidateProfile))
            {
                MessageBox.Show("add successful");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
        }

        private void dataProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromIndex(datagrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowCollumn = datagrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                String id = ((TextBlock)RowCollumn.Content).Text;
                CandidateProfile profile = profileService.GetCandidateProfile(id);
                txtCandidateID.Text = profile.CandidateId.ToString();
                txtName.Text = profile.Fullname.ToString();
                txtURL.Text = profile.ProfileUrl.ToString();
                birthDate.Text = profile.Birthday.ToString();
                txtDes.Text = profile.ProfileShortDescription.ToString();
                cmbJobPosting.SelectedValue = profile.PostingId.ToString();

            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(birthDate.Text, out DateTime birthDateValue))
                {
                    MessageBox.Show("Invalid birth date format. Please enter a valid date.");
                    return;
                }

                var candidateProfile = new CandidateProfile
                {
                    CandidateId = txtCandidateID.Text,
                    Fullname = txtName.Text,
                    Birthday = birthDateValue,
                    ProfileUrl = txtURL.Text,
                    ProfileShortDescription = txtDes.Text,
                    PostingId = cmbJobPosting.SelectedValue?.ToString() // Null check added
                };

                if (profileService.UpdateCandidateProfile(candidateProfile)) // Assuming UpdateCandidateProfile exists
                {
                    MessageBox.Show("Candidate updated successfully.");
                    LoadDataInit(); // Refresh data
                }
                else
                {
                    MessageBox.Show("Failed to update candidate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating candidate: {ex.Message}");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPostingWindow = new JobPosting();
            jobPostingWindow.Show();
            this.Close();
        }
    }
}
