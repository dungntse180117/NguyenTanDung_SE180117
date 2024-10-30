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
using System.Xml.Linq;
using Services;

namespace PRN221PE_FA22_TrialTest_StudentName_
{
    /// <summary>
    /// Interaction logic for JobPosting.xaml
    /// </summary>
    public partial class JobPosting : Window
    {
        private readonly IJobPostingService jobService;
        public JobPosting()
        {
            InitializeComponent();
            jobService = new JobPostingService();
        }

        private void LoadDataInit()
        {
            this.dataJob.ItemsSource = jobService.GetJobPostings();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure an item is selected
            if (dataJob.SelectedItem is JobPostings selectedJob)
            {
                // Display the details of the selected job posting in the text fields
                ProductID_txt.Text = selectedJob.PostingId;
                title_txt.Text = selectedJob.JobPostingTitle;
                des_txt.Text = selectedJob.Description;
                postDate.Text = selectedJob.PostedDate?.ToString("MM/dd/yyyy"); // Format date as needed
            }
            else
            {
                // Clear the fields if no job posting is selected
                ProductID_txt.Text = string.Empty;
                title_txt.Text = string.Empty;
                des_txt.Text = string.Empty;
                postDate.Text = string.Empty;
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPostings jobPosting = new JobPostings();
            jobPosting.PostingId = ProductID_txt.Text;
            jobPosting.JobPostingTitle = title_txt.Text;
            jobPosting.Description = des_txt.Text;
            jobPosting.PostedDate = DateTime.Now;
            if (jobService.addJob(jobPosting))
            {
                MessageBox.Show("add successful");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
           
            if (dataJob.SelectedItem is JobPostings selectedJob)
            {
                
                var result = MessageBox.Show(
                    "Are you sure you want to delete this job posting?",
                    "Confirm Deletion",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                
                if (result == MessageBoxResult.Yes)
                {
                   
                    bool isDeleted = jobService.delJob(selectedJob.PostingId);

                    
                    if (isDeleted)
                    {
                        MessageBox.Show("Job posting deleted successfully.");
                        this.LoadDataInit();  
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete job posting.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a job posting to delete.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataJob.SelectedItem is JobPostings selectedJob)
            {
                selectedJob.PostingId = ProductID_txt.Text;
                selectedJob.JobPostingTitle = title_txt.Text;
                selectedJob.Description = des_txt.Text;

                if (DateTime.TryParse(postDate.Text, out DateTime parsedDate))
                {
                    selectedJob.PostedDate = parsedDate;
                }
                else
                {
                    MessageBox.Show("Invalid date format. Please enter a valid date.");
                    return;
                }

                // If UpdateJob accepts a JobPostings object
                bool isUpdated = jobService.UpdateJob(selectedJob);

                if (isUpdated)
                {
                    MessageBox.Show("Job posting updated successfully.");
                    this.LoadDataInit();
                }
                else
                {
                    MessageBox.Show("Failed to update job posting.");
                }
            }
            else
            {
                MessageBox.Show("Please select a job posting to update.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Candidate cadi = new Candidate();
            cadi.Show();
            this.Close();
        }
    }
}
