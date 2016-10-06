
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISpySoft.FeatureModelLanguage.Designer
	{
	#region Using directives

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using Microsoft.VisualStudio.EnterpriseTools.Shell;
	using Microsoft.VisualStudio.Modeling;
	using Microsoft.VisualStudio.Modeling.Validation;
	using Microsoft.VisualStudio.Modeling.Shell;
	using Microsoft.VisualStudio.Modeling.ArtifactMapper;
	using ISpySoft.FeatureModelLanguage.Designer.Properties;
	using ISpySoft.FeatureModelLanguage.Designer.Shell;
	using System.Collections;
	using System.Windows.Forms;
	using System.IO;
	using Microsoft.VisualStudio.Modeling.Utilities;
	using ISpySoft.FeatureModelLanguage.Designer.Diagram; // For resource class
	using VsShell = Microsoft.VisualStudio.Shell.Interop;
	#endregion

	[CLSCompliant(false)]
	public class FeatureModelLanguageDocData : ImsDocData
	{

		#region Constraint ValidationController
		/// <summary>
		/// The controller for all validation that goes on in the package.
		/// </summary>
		private VsValidationController validationController;
		private ErrorListObserver errorListObserver;
		#endregion

		internal FeatureModelLanguageDocData(IServiceProvider serviceProvider, EditorFactory editorFactory) : base(serviceProvider, editorFactory)
		{
		}
		
		/// <summary>
		/// Identify substores in the serialized models by name.
		/// </summary>
		/// <value></value>
		protected override bool IdentifySubStoresByName
		{
			get { return true; }
		}

		/// <summary>
		/// Called after the metamodels have been loaded into the store
		/// </summary>
		/// <param name="storeKey"></param>
		/// <param name="store"></param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ISpySoft.FeatureModelLanguage.Designer.Shell.FeatureModelLanguagePropertyDescriptionRedirector")]
		protected override void AfterMetaModelsLoaded(object storeKey, Store store)
		{
			// Create the store-specific property description redirector
			new FeatureModelLanguagePropertyDescriptionRedirector(this.ServiceProvider, this.Store);
		}

		/// <summary>
		/// Add the domain models that are specific to this designer
		/// </summary>
		/// <param name="domainModels"></param>
		protected override void AddDesignerSpecificDomainModels(IList domainModels)
		{
			domainModels.Add(typeof(ISpySoft.FeatureModelLanguage.DomainModel.FeatureModelLanguage));
			domainModels.Add(typeof(ISpySoft.FeatureModelLanguage.Designer.FeatureModelLanguageDesigner));
		}

		protected override string FormatList
		{
			get
			{
				// This interim code allows the language author to put the resource either in the
				// Properties\Resources or in Diagram\Resources. The former is deprecated.
				string formatList = EditorFactory.GetResource("FormatList") as string;
				return formatList.Replace("|", "\n");
			}
		}

		public override DefaultDesignerCallbacks CreateDefaultDesignerCallbacks()
		{
			return new DesignerCallbacks(this.ServiceProvider);
		}

		protected override ElementProvider[] GetElementProviders(Store store, object storeKey)
		{
			return new ElementProvider[0];
		}
				
		#region Constraint Support
		/// <summary>
		/// The controller for all validation that goes on in the package.
		/// </summary>
		internal VsValidationController ValidationController
		{
			get
			{
				if (this.validationController == null)
				{
					this.validationController = new VsValidationController(this.ServiceProvider);

					this.errorListObserver = new ErrorListObserver(this.ServiceProvider);

					// register the observer so we can show the error/warning/msg in the VS output window.
					this.validationController.AddObserver(this.errorListObserver);
				}
				return this.validationController;
			}
		}
		
		/// <summary>
		/// When the doc data is closed, make sure we reset the valiation messages 
		/// (if there's any) from the ErrorList window.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (this.validationController != null)
				{
					this.validationController.ClearMessages();
					// un-register our observer with the controller.
					if (this.errorListObserver != null)
					{
						this.validationController.RemoveObserver(this.errorListObserver);
						
						this.errorListObserver.Dispose();
						this.errorListObserver = null;
					}
					this.validationController = null;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		/// <summary>
		/// After the document is opened, validation the model.
		/// </summary>
		/// <param name="e">Event Args.</param>
		protected override void OnDocumentLoaded(EventArgs e)
		{
			base.OnDocumentLoaded(e);

			// Validate the document
			ValidationCategory category = ValidationCategory.Open;
#if DEBUG
			category |= ValidationCategory.Debug;
#endif
			this.ValidationController.Validate(this.Store, category);
		}
		/// <summary>
		/// Validate the model before the file is saved.
		/// </summary>
		/// <param name="fileName"></param>
		protected override void Save(string fileName)
		{
			DialogResult result = DialogResult.Yes;
			ValidationCategory category = ValidationCategory.Save;
#if DEBUG
			category |= ValidationCategory.Debug;
#endif
			if (!this.ValidationController.Validate(this.Store, category))
			{
				result = PackageUtility.ShowMessageBox(this.ServiceProvider, Designer_Resource.SaveValidationFailed, VsShell.OLEMSGBUTTON.OLEMSGBUTTON_YESNO, VsShell.OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_SECOND, VsShell.OLEMSGICON.OLEMSGICON_WARNING);
			}

			if (result == DialogResult.Yes)
			{
				// Save the model now!
				base.Save(fileName);
			}
			else
			{	// Throw E_ABORT so that VS shell knows that the save operation is canceled.
				throw new System.Runtime.InteropServices.COMException ( Designer_Resource.SaveOperationCancelled, Microsoft.VisualStudio.VSConstants.E_ABORT);
			}
		}
		#endregion

		#region Diagram/Document mapping support
		/// <summary>
		/// </summary>
		/// <returns>The type</returns>
		protected override Type DiagramMappedElementType
		{
			get
			{
				return typeof(ISpySoft.FeatureModelLanguage.DomainModel.FeatureModel);
			}
		}

		/// <summary>
		/// Create a default element to maps to the diagram
		/// </summary>
		/// <remarks>
		/// Override this if your serialization format does not or may not contain all elements and you need to make a standard element to map your diagram to.
		/// This is useful to support empty files as blank models.
		/// </remarks>
		/// <returns>A mode element to map to a diagram or null on error</returns>
		protected override ModelElement CreateDefaultDiagramMappedElement()
		{
			ISpySoft.FeatureModelLanguage.DomainModel.FeatureModel mappedElement = ISpySoft.FeatureModelLanguage.DomainModel.FeatureModel.CreateFeatureModel(this.Store);
			return mappedElement;
		}
		#endregion

		#region Load/Save Support
		/// <summary>
		/// Get the type that is the XML root for serialization
		/// </summary>
		/// <returns>The type</returns>
		protected override Type XmlSerializationRootType
		{
			get
			{
				return typeof(ISpySoft.FeatureModelLanguage.DomainModel.FeatureModel);
			}
		}

		protected override Microsoft.VisualStudio.Modeling.Utilities.Diagram CreateDefaultDiagram(ModelElement mappedElement)
		{
			FeatureModelLanguageDiagram diagram = null;

			diagram = FeatureModelLanguageDiagram.CreateFeatureModelLanguageDiagram(this.Store);
			return diagram;
		}
		#endregion
	}
}
