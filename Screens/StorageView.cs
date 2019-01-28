using Terminal.Gui;

namespace StandaloneExample.Screens {
    class StorageView {
		public static Window generateWindow(Window baseWindow)
		{
			Window storageView = new Window(new Rect(0, 0, baseWindow.Frame.Width - 2, baseWindow.Frame.Height - 2), "Storage");
			
			var currenFilesWindow = generateCurrentFilesWindow(baseWindow);
   			var optionsWindow = generateOptionsMenuWindow(baseWindow);
	    		var statisticsWindow = generateStatisticsWindow(baseWindow);

			storageView.Add(
				currenFilesWindow,
				optionsWindow,
				statisticsWindow
				
			);
			
			return storageView;
		}

		public static Window generateCurrentFilesWindow(Window baseWindow){
			Window fileStored = new Window(new Rect(0, 0, 70, 14), "Current Files");

	    var listFiles = new ListView(new Rect(0, 1, 65, 12), new string[] {
		"FamilyPictures/",
		"resume.docx",
		"sindhi_book.pdf",
		"MyMusic/",
		"Screen Shot 2018-01-09 at 3..38.55 PM.png",
		"DoNotEnterHere/"
		});


			
	    	fileStored.Add(listFiles);
	    	return fileStored;
		
		}


		public static Window generateOptionsMenuWindow(Window baseWindow) { 
			Window optionsWindow = new Window(new Rect(0, 14, 70, 3), "Options");
	    	
			var uploadButton = new Button("Upload New"){
				X = 0,
				Y = 0
			};
			optionsWindow.Add(uploadButton);

	    	return optionsWindow;	
		}

		public static Window generateStatisticsWindow(Window baseWindow) { 
			Window statsWindow = new Window(new Rect(0, 17, 70, 3), "Statistics");
	    	
				var costPerDay = new TextView( new Rect(0,0,70,1)){
					Text = "0.12 K/day"
				};
				statsWindow.Add(costPerDay);		

	    		return statsWindow;	
		}
    }

}
