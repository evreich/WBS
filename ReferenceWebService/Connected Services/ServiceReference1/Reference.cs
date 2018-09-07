//------------------------------------------------------------------------------
// <автоматически создаваемое>
//     Этот код создан программой.
//     //
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </автоматически создаваемое>
//------------------------------------------------------------------------------

namespace ServiceReference1
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/", ConfigurationName = "ServiceReference1.ListsSoap")]
    public interface ListsSoap
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetList", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListResponse> GetListAsync(ServiceReference1.GetListRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListAndView", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListAndViewResponse> GetListAndViewAsync(ServiceReference1.GetListAndViewRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/DeleteList", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.DeleteListResponse> DeleteListAsync(ServiceReference1.DeleteListRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/AddList", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.AddListResponse> AddListAsync(ServiceReference1.AddListRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/AddListFromFeature", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.AddListFromFeatureResponse> AddListFromFeatureAsync(ServiceReference1.AddListFromFeatureRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateList", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListResponse> UpdateListAsync(ServiceReference1.UpdateListRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListCollection", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListCollectionResponse> GetListCollectionAsync(ServiceReference1.GetListCollectionRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListItems", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemsResponse> GetListItemsAsync(ServiceReference1.GetListItemsRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListItemChanges", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesResponse> GetListItemChangesAsync(ServiceReference1.GetListItemChangesRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListItemChangesWithKnowledge", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesWithKnowledgeResponse> GetListItemChangesWithKnowledgeAsync(ServiceReference1.GetListItemChangesWithKnowledgeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListItemChangesSinceToken", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesSinceTokenResponse> GetListItemChangesSinceTokenAsync(ServiceReference1.GetListItemChangesSinceTokenRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateListItems", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsResponse> UpdateListItemsAsync(ServiceReference1.UpdateListItemsRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateListItemsWithKnowledge", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsWithKnowledgeResponse> UpdateListItemsWithKnowledgeAsync(ServiceReference1.UpdateListItemsWithKnowledgeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/AddDiscussionBoardItem", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.AddDiscussionBoardItemResponse> AddDiscussionBoardItemAsync(ServiceReference1.AddDiscussionBoardItemRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/AddWikiPage", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.AddWikiPageResponse> AddWikiPageAsync(ServiceReference1.AddWikiPageRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetVersionCollection", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetVersionCollectionResponse> GetVersionCollectionAsync(ServiceReference1.GetVersionCollectionRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/AddAttachment", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.AddAttachmentResponse> AddAttachmentAsync(ServiceReference1.AddAttachmentRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetAttachmentCollection", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetAttachmentCollectionResponse> GetAttachmentCollectionAsync(ServiceReference1.GetAttachmentCollectionRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/DeleteAttachment", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.DeleteAttachmentResponse> DeleteAttachmentAsync(ServiceReference1.DeleteAttachmentRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/CheckOutFile", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.CheckOutFileResponse> CheckOutFileAsync(ServiceReference1.CheckOutFileRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UndoCheckOut", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UndoCheckOutResponse> UndoCheckOutAsync(ServiceReference1.UndoCheckOutRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/CheckInFile", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.CheckInFileResponse> CheckInFileAsync(ServiceReference1.CheckInFileRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListContentTypes", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesResponse> GetListContentTypesAsync(ServiceReference1.GetListContentTypesRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListContentTypesAndProperties", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesAndPropertiesResponse> GetListContentTypesAndPropertiesAsync(ServiceReference1.GetListContentTypesAndPropertiesRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/GetListContentType", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypeResponse> GetListContentTypeAsync(ServiceReference1.GetListContentTypeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/CreateContentType", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.CreateContentTypeResponse> CreateContentTypeAsync(ServiceReference1.CreateContentTypeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateContentType", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeResponse> UpdateContentTypeAsync(ServiceReference1.UpdateContentTypeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/DeleteContentType", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeResponse> DeleteContentTypeAsync(ServiceReference1.DeleteContentTypeRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateContentTypeXmlDocument", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeXmlDocumentResponse> UpdateContentTypeXmlDocumentAsync(ServiceReference1.UpdateContentTypeXmlDocumentRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/UpdateContentTypesXmlDocument", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypesXmlDocumentResponse> UpdateContentTypesXmlDocumentAsync(ServiceReference1.UpdateContentTypesXmlDocumentRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/DeleteContentTypeXmlDocument", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeXmlDocumentResponse> DeleteContentTypeXmlDocumentAsync(ServiceReference1.DeleteContentTypeXmlDocumentRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://schemas.microsoft.com/sharepoint/soap/ApplyContentTypeToList", ReplyAction = "*")]
        System.Threading.Tasks.Task<ServiceReference1.ApplyContentTypeToListResponse> ApplyContentTypeToListAsync(ServiceReference1.ApplyContentTypeToListRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetList", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListRequestBody Body;

        public GetListRequest()
        {
        }

        public GetListRequest(ServiceReference1.GetListRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        public GetListRequestBody()
        {
        }

        public GetListRequestBody(string listName)
        {
            this.listName = listName;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListResponseBody Body;

        public GetListResponse()
        {
        }

        public GetListResponse(ServiceReference1.GetListResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListResult;

        public GetListResponseBody()
        {
        }

        public GetListResponseBody(System.Xml.Linq.XElement GetListResult)
        {
            this.GetListResult = GetListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListAndViewRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListAndView", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListAndViewRequestBody Body;

        public GetListAndViewRequest()
        {
        }

        public GetListAndViewRequest(ServiceReference1.GetListAndViewRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListAndViewRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string viewName;

        public GetListAndViewRequestBody()
        {
        }

        public GetListAndViewRequestBody(string listName, string viewName)
        {
            this.listName = listName;
            this.viewName = viewName;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListAndViewResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListAndViewResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListAndViewResponseBody Body;

        public GetListAndViewResponse()
        {
        }

        public GetListAndViewResponse(ServiceReference1.GetListAndViewResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListAndViewResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListAndViewResult;

        public GetListAndViewResponseBody()
        {
        }

        public GetListAndViewResponseBody(System.Xml.Linq.XElement GetListAndViewResult)
        {
            this.GetListAndViewResult = GetListAndViewResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteList", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteListRequestBody Body;

        public DeleteListRequest()
        {
        }

        public DeleteListRequest(ServiceReference1.DeleteListRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteListRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        public DeleteListRequestBody()
        {
        }

        public DeleteListRequestBody(string listName)
        {
            this.listName = listName;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteListResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteListResponseBody Body;

        public DeleteListResponse()
        {
        }

        public DeleteListResponse(ServiceReference1.DeleteListResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class DeleteListResponseBody
    {

        public DeleteListResponseBody()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddList", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddListRequestBody Body;

        public AddListRequest()
        {
        }

        public AddListRequest(ServiceReference1.AddListRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddListRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string description;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public int templateID;

        public AddListRequestBody()
        {
        }

        public AddListRequestBody(string listName, string description, int templateID)
        {
            this.listName = listName;
            this.description = description;
            this.templateID = templateID;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddListResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddListResponseBody Body;

        public AddListResponse()
        {
        }

        public AddListResponse(ServiceReference1.AddListResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddListResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement AddListResult;

        public AddListResponseBody()
        {
        }

        public AddListResponseBody(System.Xml.Linq.XElement AddListResult)
        {
            this.AddListResult = AddListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddListFromFeatureRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddListFromFeature", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddListFromFeatureRequestBody Body;

        public AddListFromFeatureRequest()
        {
        }

        public AddListFromFeatureRequest(ServiceReference1.AddListFromFeatureRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddListFromFeatureRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string description;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string featureID;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public int templateID;

        public AddListFromFeatureRequestBody()
        {
        }

        public AddListFromFeatureRequestBody(string listName, string description, string featureID, int templateID)
        {
            this.listName = listName;
            this.description = description;
            this.featureID = featureID;
            this.templateID = templateID;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddListFromFeatureResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddListFromFeatureResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddListFromFeatureResponseBody Body;

        public AddListFromFeatureResponse()
        {
        }

        public AddListFromFeatureResponse(ServiceReference1.AddListFromFeatureResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddListFromFeatureResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement AddListFromFeatureResult;

        public AddListFromFeatureResponseBody()
        {
        }

        public AddListFromFeatureResponseBody(System.Xml.Linq.XElement AddListFromFeatureResult)
        {
            this.AddListFromFeatureResult = AddListFromFeatureResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateList", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListRequestBody Body;

        public UpdateListRequest()
        {
        }

        public UpdateListRequest(ServiceReference1.UpdateListRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public System.Xml.Linq.XElement listProperties;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement newFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement updateFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public System.Xml.Linq.XElement deleteFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public string listVersion;

        public UpdateListRequestBody()
        {
        }

        public UpdateListRequestBody(string listName, System.Xml.Linq.XElement listProperties, System.Xml.Linq.XElement newFields, System.Xml.Linq.XElement updateFields, System.Xml.Linq.XElement deleteFields, string listVersion)
        {
            this.listName = listName;
            this.listProperties = listProperties;
            this.newFields = newFields;
            this.updateFields = updateFields;
            this.deleteFields = deleteFields;
            this.listVersion = listVersion;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateListResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListResponseBody Body;

        public UpdateListResponse()
        {
        }

        public UpdateListResponse(ServiceReference1.UpdateListResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateListResult;

        public UpdateListResponseBody()
        {
        }

        public UpdateListResponseBody(System.Xml.Linq.XElement UpdateListResult)
        {
            this.UpdateListResult = UpdateListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListCollectionRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListCollection", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListCollectionRequestBody Body;

        public GetListCollectionRequest()
        {
        }

        public GetListCollectionRequest(ServiceReference1.GetListCollectionRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetListCollectionRequestBody
    {

        public GetListCollectionRequestBody()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListCollectionResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListCollectionResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListCollectionResponseBody Body;

        public GetListCollectionResponse()
        {
        }

        public GetListCollectionResponse(ServiceReference1.GetListCollectionResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListCollectionResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListCollectionResult;

        public GetListCollectionResponseBody()
        {
        }

        public GetListCollectionResponseBody(System.Xml.Linq.XElement GetListCollectionResult)
        {
            this.GetListCollectionResult = GetListCollectionResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemsRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItems", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemsRequestBody Body;

        public GetListItemsRequest()
        {
        }

        public GetListItemsRequest(ServiceReference1.GetListItemsRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemsRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string viewName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement query;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement viewFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string rowLimit;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public System.Xml.Linq.XElement queryOptions;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string webID;

        public GetListItemsRequestBody()
        {
        }

        public GetListItemsRequestBody(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string webID)
        {
            this.listName = listName;
            this.viewName = viewName;
            this.query = query;
            this.viewFields = viewFields;
            this.rowLimit = rowLimit;
            this.queryOptions = queryOptions;
            this.webID = webID;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemsResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemsResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemsResponseBody Body;

        public GetListItemsResponse()
        {
        }

        public GetListItemsResponse(ServiceReference1.GetListItemsResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemsResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListItemsResult;

        public GetListItemsResponseBody()
        {
        }

        public GetListItemsResponseBody(System.Xml.Linq.XElement GetListItemsResult)
        {
            this.GetListItemsResult = GetListItemsResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChanges", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesRequestBody Body;

        public GetListItemChangesRequest()
        {
        }

        public GetListItemChangesRequest(ServiceReference1.GetListItemChangesRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public System.Xml.Linq.XElement viewFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string since;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement contains;

        public GetListItemChangesRequestBody()
        {
        }

        public GetListItemChangesRequestBody(string listName, System.Xml.Linq.XElement viewFields, string since, System.Xml.Linq.XElement contains)
        {
            this.listName = listName;
            this.viewFields = viewFields;
            this.since = since;
            this.contains = contains;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChangesResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesResponseBody Body;

        public GetListItemChangesResponse()
        {
        }

        public GetListItemChangesResponse(ServiceReference1.GetListItemChangesResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListItemChangesResult;

        public GetListItemChangesResponseBody()
        {
        }

        public GetListItemChangesResponseBody(System.Xml.Linq.XElement GetListItemChangesResult)
        {
            this.GetListItemChangesResult = GetListItemChangesResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesWithKnowledgeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChangesWithKnowledge", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesWithKnowledgeRequestBody Body;

        public GetListItemChangesWithKnowledgeRequest()
        {
        }

        public GetListItemChangesWithKnowledgeRequest(ServiceReference1.GetListItemChangesWithKnowledgeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesWithKnowledgeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string viewName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement query;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement viewFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string rowLimit;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public System.Xml.Linq.XElement queryOptions;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string syncScope;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 7)]
        public System.Xml.Linq.XElement knowledge;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 8)]
        public System.Xml.Linq.XElement contains;

        public GetListItemChangesWithKnowledgeRequestBody()
        {
        }

        public GetListItemChangesWithKnowledgeRequestBody(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string syncScope, System.Xml.Linq.XElement knowledge, System.Xml.Linq.XElement contains)
        {
            this.listName = listName;
            this.viewName = viewName;
            this.query = query;
            this.viewFields = viewFields;
            this.rowLimit = rowLimit;
            this.queryOptions = queryOptions;
            this.syncScope = syncScope;
            this.knowledge = knowledge;
            this.contains = contains;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesWithKnowledgeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChangesWithKnowledgeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesWithKnowledgeResponseBody Body;

        public GetListItemChangesWithKnowledgeResponse()
        {
        }

        public GetListItemChangesWithKnowledgeResponse(ServiceReference1.GetListItemChangesWithKnowledgeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesWithKnowledgeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListItemChangesWithKnowledgeResult;

        public GetListItemChangesWithKnowledgeResponseBody()
        {
        }

        public GetListItemChangesWithKnowledgeResponseBody(System.Xml.Linq.XElement GetListItemChangesWithKnowledgeResult)
        {
            this.GetListItemChangesWithKnowledgeResult = GetListItemChangesWithKnowledgeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesSinceTokenRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChangesSinceToken", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesSinceTokenRequestBody Body;

        public GetListItemChangesSinceTokenRequest()
        {
        }

        public GetListItemChangesSinceTokenRequest(ServiceReference1.GetListItemChangesSinceTokenRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesSinceTokenRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string viewName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement query;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement viewFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string rowLimit;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public System.Xml.Linq.XElement queryOptions;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string changeToken;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 7)]
        public System.Xml.Linq.XElement contains;

        public GetListItemChangesSinceTokenRequestBody()
        {
        }

        public GetListItemChangesSinceTokenRequestBody(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string changeToken, System.Xml.Linq.XElement contains)
        {
            this.listName = listName;
            this.viewName = viewName;
            this.query = query;
            this.viewFields = viewFields;
            this.rowLimit = rowLimit;
            this.queryOptions = queryOptions;
            this.changeToken = changeToken;
            this.contains = contains;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListItemChangesSinceTokenResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListItemChangesSinceTokenResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListItemChangesSinceTokenResponseBody Body;

        public GetListItemChangesSinceTokenResponse()
        {
        }

        public GetListItemChangesSinceTokenResponse(ServiceReference1.GetListItemChangesSinceTokenResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListItemChangesSinceTokenResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListItemChangesSinceTokenResult;

        public GetListItemChangesSinceTokenResponseBody()
        {
        }

        public GetListItemChangesSinceTokenResponseBody(System.Xml.Linq.XElement GetListItemChangesSinceTokenResult)
        {
            this.GetListItemChangesSinceTokenResult = GetListItemChangesSinceTokenResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListItemsRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateListItems", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListItemsRequestBody Body;

        public UpdateListItemsRequest()
        {
        }

        public UpdateListItemsRequest(ServiceReference1.UpdateListItemsRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListItemsRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public System.Xml.Linq.XElement updates;

        public UpdateListItemsRequestBody()
        {
        }

        public UpdateListItemsRequestBody(string listName, System.Xml.Linq.XElement updates)
        {
            this.listName = listName;
            this.updates = updates;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListItemsResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateListItemsResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListItemsResponseBody Body;

        public UpdateListItemsResponse()
        {
        }

        public UpdateListItemsResponse(ServiceReference1.UpdateListItemsResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListItemsResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateListItemsResult;

        public UpdateListItemsResponseBody()
        {
        }

        public UpdateListItemsResponseBody(System.Xml.Linq.XElement UpdateListItemsResult)
        {
            this.UpdateListItemsResult = UpdateListItemsResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListItemsWithKnowledgeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateListItemsWithKnowledge", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListItemsWithKnowledgeRequestBody Body;

        public UpdateListItemsWithKnowledgeRequest()
        {
        }

        public UpdateListItemsWithKnowledgeRequest(ServiceReference1.UpdateListItemsWithKnowledgeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListItemsWithKnowledgeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public System.Xml.Linq.XElement updates;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string syncScope;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement knowledge;

        public UpdateListItemsWithKnowledgeRequestBody()
        {
        }

        public UpdateListItemsWithKnowledgeRequestBody(string listName, System.Xml.Linq.XElement updates, string syncScope, System.Xml.Linq.XElement knowledge)
        {
            this.listName = listName;
            this.updates = updates;
            this.syncScope = syncScope;
            this.knowledge = knowledge;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateListItemsWithKnowledgeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateListItemsWithKnowledgeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateListItemsWithKnowledgeResponseBody Body;

        public UpdateListItemsWithKnowledgeResponse()
        {
        }

        public UpdateListItemsWithKnowledgeResponse(ServiceReference1.UpdateListItemsWithKnowledgeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateListItemsWithKnowledgeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateListItemsWithKnowledgeResult;

        public UpdateListItemsWithKnowledgeResponseBody()
        {
        }

        public UpdateListItemsWithKnowledgeResponseBody(System.Xml.Linq.XElement UpdateListItemsWithKnowledgeResult)
        {
            this.UpdateListItemsWithKnowledgeResult = UpdateListItemsWithKnowledgeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddDiscussionBoardItemRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddDiscussionBoardItem", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddDiscussionBoardItemRequestBody Body;

        public AddDiscussionBoardItemRequest()
        {
        }

        public AddDiscussionBoardItemRequest(ServiceReference1.AddDiscussionBoardItemRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddDiscussionBoardItemRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public byte[] message;

        public AddDiscussionBoardItemRequestBody()
        {
        }

        public AddDiscussionBoardItemRequestBody(string listName, byte[] message)
        {
            this.listName = listName;
            this.message = message;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddDiscussionBoardItemResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddDiscussionBoardItemResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddDiscussionBoardItemResponseBody Body;

        public AddDiscussionBoardItemResponse()
        {
        }

        public AddDiscussionBoardItemResponse(ServiceReference1.AddDiscussionBoardItemResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddDiscussionBoardItemResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement AddDiscussionBoardItemResult;

        public AddDiscussionBoardItemResponseBody()
        {
        }

        public AddDiscussionBoardItemResponseBody(System.Xml.Linq.XElement AddDiscussionBoardItemResult)
        {
            this.AddDiscussionBoardItemResult = AddDiscussionBoardItemResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddWikiPageRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddWikiPage", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddWikiPageRequestBody Body;

        public AddWikiPageRequest()
        {
        }

        public AddWikiPageRequest(ServiceReference1.AddWikiPageRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddWikiPageRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string strListName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string listRelPageUrl;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string wikiContent;

        public AddWikiPageRequestBody()
        {
        }

        public AddWikiPageRequestBody(string strListName, string listRelPageUrl, string wikiContent)
        {
            this.strListName = strListName;
            this.listRelPageUrl = listRelPageUrl;
            this.wikiContent = wikiContent;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddWikiPageResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddWikiPageResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddWikiPageResponseBody Body;

        public AddWikiPageResponse()
        {
        }

        public AddWikiPageResponse(ServiceReference1.AddWikiPageResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddWikiPageResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement AddWikiPageResult;

        public AddWikiPageResponseBody()
        {
        }

        public AddWikiPageResponseBody(System.Xml.Linq.XElement AddWikiPageResult)
        {
            this.AddWikiPageResult = AddWikiPageResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetVersionCollectionRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetVersionCollection", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetVersionCollectionRequestBody Body;

        public GetVersionCollectionRequest()
        {
        }

        public GetVersionCollectionRequest(ServiceReference1.GetVersionCollectionRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetVersionCollectionRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string strlistID;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string strlistItemID;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string strFieldName;

        public GetVersionCollectionRequestBody()
        {
        }

        public GetVersionCollectionRequestBody(string strlistID, string strlistItemID, string strFieldName)
        {
            this.strlistID = strlistID;
            this.strlistItemID = strlistItemID;
            this.strFieldName = strFieldName;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetVersionCollectionResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetVersionCollectionResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetVersionCollectionResponseBody Body;

        public GetVersionCollectionResponse()
        {
        }

        public GetVersionCollectionResponse(ServiceReference1.GetVersionCollectionResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetVersionCollectionResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetVersionCollectionResult;

        public GetVersionCollectionResponseBody()
        {
        }

        public GetVersionCollectionResponseBody(System.Xml.Linq.XElement GetVersionCollectionResult)
        {
            this.GetVersionCollectionResult = GetVersionCollectionResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddAttachmentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddAttachment", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddAttachmentRequestBody Body;

        public AddAttachmentRequest()
        {
        }

        public AddAttachmentRequest(ServiceReference1.AddAttachmentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddAttachmentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string listItemID;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string fileName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public byte[] attachment;

        public AddAttachmentRequestBody()
        {
        }

        public AddAttachmentRequestBody(string listName, string listItemID, string fileName, byte[] attachment)
        {
            this.listName = listName;
            this.listItemID = listItemID;
            this.fileName = fileName;
            this.attachment = attachment;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class AddAttachmentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "AddAttachmentResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.AddAttachmentResponseBody Body;

        public AddAttachmentResponse()
        {
        }

        public AddAttachmentResponse(ServiceReference1.AddAttachmentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class AddAttachmentResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string AddAttachmentResult;

        public AddAttachmentResponseBody()
        {
        }

        public AddAttachmentResponseBody(string AddAttachmentResult)
        {
            this.AddAttachmentResult = AddAttachmentResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAttachmentCollectionRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetAttachmentCollection", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetAttachmentCollectionRequestBody Body;

        public GetAttachmentCollectionRequest()
        {
        }

        public GetAttachmentCollectionRequest(ServiceReference1.GetAttachmentCollectionRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetAttachmentCollectionRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string listItemID;

        public GetAttachmentCollectionRequestBody()
        {
        }

        public GetAttachmentCollectionRequestBody(string listName, string listItemID)
        {
            this.listName = listName;
            this.listItemID = listItemID;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetAttachmentCollectionResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetAttachmentCollectionResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetAttachmentCollectionResponseBody Body;

        public GetAttachmentCollectionResponse()
        {
        }

        public GetAttachmentCollectionResponse(ServiceReference1.GetAttachmentCollectionResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetAttachmentCollectionResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetAttachmentCollectionResult;

        public GetAttachmentCollectionResponseBody()
        {
        }

        public GetAttachmentCollectionResponseBody(System.Xml.Linq.XElement GetAttachmentCollectionResult)
        {
            this.GetAttachmentCollectionResult = GetAttachmentCollectionResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteAttachmentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteAttachment", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteAttachmentRequestBody Body;

        public DeleteAttachmentRequest()
        {
        }

        public DeleteAttachmentRequest(ServiceReference1.DeleteAttachmentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteAttachmentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string listItemID;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string url;

        public DeleteAttachmentRequestBody()
        {
        }

        public DeleteAttachmentRequestBody(string listName, string listItemID, string url)
        {
            this.listName = listName;
            this.listItemID = listItemID;
            this.url = url;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteAttachmentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteAttachmentResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteAttachmentResponseBody Body;

        public DeleteAttachmentResponse()
        {
        }

        public DeleteAttachmentResponse(ServiceReference1.DeleteAttachmentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class DeleteAttachmentResponseBody
    {

        public DeleteAttachmentResponseBody()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CheckOutFileRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CheckOutFile", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CheckOutFileRequestBody Body;

        public CheckOutFileRequest()
        {
        }

        public CheckOutFileRequest(ServiceReference1.CheckOutFileRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CheckOutFileRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string pageUrl;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string checkoutToLocal;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string lastmodified;

        public CheckOutFileRequestBody()
        {
        }

        public CheckOutFileRequestBody(string pageUrl, string checkoutToLocal, string lastmodified)
        {
            this.pageUrl = pageUrl;
            this.checkoutToLocal = checkoutToLocal;
            this.lastmodified = lastmodified;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CheckOutFileResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CheckOutFileResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CheckOutFileResponseBody Body;

        public CheckOutFileResponse()
        {
        }

        public CheckOutFileResponse(ServiceReference1.CheckOutFileResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CheckOutFileResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public bool CheckOutFileResult;

        public CheckOutFileResponseBody()
        {
        }

        public CheckOutFileResponseBody(bool CheckOutFileResult)
        {
            this.CheckOutFileResult = CheckOutFileResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UndoCheckOutRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UndoCheckOut", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UndoCheckOutRequestBody Body;

        public UndoCheckOutRequest()
        {
        }

        public UndoCheckOutRequest(ServiceReference1.UndoCheckOutRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UndoCheckOutRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string pageUrl;

        public UndoCheckOutRequestBody()
        {
        }

        public UndoCheckOutRequestBody(string pageUrl)
        {
            this.pageUrl = pageUrl;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UndoCheckOutResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UndoCheckOutResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UndoCheckOutResponseBody Body;

        public UndoCheckOutResponse()
        {
        }

        public UndoCheckOutResponse(ServiceReference1.UndoCheckOutResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UndoCheckOutResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public bool UndoCheckOutResult;

        public UndoCheckOutResponseBody()
        {
        }

        public UndoCheckOutResponseBody(bool UndoCheckOutResult)
        {
            this.UndoCheckOutResult = UndoCheckOutResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CheckInFileRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CheckInFile", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CheckInFileRequestBody Body;

        public CheckInFileRequest()
        {
        }

        public CheckInFileRequest(ServiceReference1.CheckInFileRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CheckInFileRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string pageUrl;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string comment;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string CheckinType;

        public CheckInFileRequestBody()
        {
        }

        public CheckInFileRequestBody(string pageUrl, string comment, string CheckinType)
        {
            this.pageUrl = pageUrl;
            this.comment = comment;
            this.CheckinType = CheckinType;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CheckInFileResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CheckInFileResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CheckInFileResponseBody Body;

        public CheckInFileResponse()
        {
        }

        public CheckInFileResponse(ServiceReference1.CheckInFileResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CheckInFileResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public bool CheckInFileResult;

        public CheckInFileResponseBody()
        {
        }

        public CheckInFileResponseBody(bool CheckInFileResult)
        {
            this.CheckInFileResult = CheckInFileResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypesRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentTypes", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypesRequestBody Body;

        public GetListContentTypesRequest()
        {
        }

        public GetListContentTypesRequest(ServiceReference1.GetListContentTypesRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypesRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        public GetListContentTypesRequestBody()
        {
        }

        public GetListContentTypesRequestBody(string listName, string contentTypeId)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypesResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentTypesResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypesResponseBody Body;

        public GetListContentTypesResponse()
        {
        }

        public GetListContentTypesResponse(ServiceReference1.GetListContentTypesResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypesResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListContentTypesResult;

        public GetListContentTypesResponseBody()
        {
        }

        public GetListContentTypesResponseBody(System.Xml.Linq.XElement GetListContentTypesResult)
        {
            this.GetListContentTypesResult = GetListContentTypesResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypesAndPropertiesRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentTypesAndProperties", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypesAndPropertiesRequestBody Body;

        public GetListContentTypesAndPropertiesRequest()
        {
        }

        public GetListContentTypesAndPropertiesRequest(ServiceReference1.GetListContentTypesAndPropertiesRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypesAndPropertiesRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string propertyPrefix;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public bool includeWebProperties;

        public GetListContentTypesAndPropertiesRequestBody()
        {
        }

        public GetListContentTypesAndPropertiesRequestBody(string listName, string contentTypeId, string propertyPrefix, bool includeWebProperties)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
            this.propertyPrefix = propertyPrefix;
            this.includeWebProperties = includeWebProperties;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypesAndPropertiesResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentTypesAndPropertiesResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypesAndPropertiesResponseBody Body;

        public GetListContentTypesAndPropertiesResponse()
        {
        }

        public GetListContentTypesAndPropertiesResponse(ServiceReference1.GetListContentTypesAndPropertiesResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypesAndPropertiesResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListContentTypesAndPropertiesResult;

        public GetListContentTypesAndPropertiesResponseBody()
        {
        }

        public GetListContentTypesAndPropertiesResponseBody(System.Xml.Linq.XElement GetListContentTypesAndPropertiesResult)
        {
            this.GetListContentTypesAndPropertiesResult = GetListContentTypesAndPropertiesResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentType", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypeRequestBody Body;

        public GetListContentTypeRequest()
        {
        }

        public GetListContentTypeRequest(ServiceReference1.GetListContentTypeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        public GetListContentTypeRequestBody()
        {
        }

        public GetListContentTypeRequestBody(string listName, string contentTypeId)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetListContentTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetListContentTypeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.GetListContentTypeResponseBody Body;

        public GetListContentTypeResponse()
        {
        }

        public GetListContentTypeResponse(ServiceReference1.GetListContentTypeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class GetListContentTypeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement GetListContentTypeResult;

        public GetListContentTypeResponseBody()
        {
        }

        public GetListContentTypeResponseBody(System.Xml.Linq.XElement GetListContentTypeResult)
        {
            this.GetListContentTypeResult = GetListContentTypeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CreateContentTypeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CreateContentType", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CreateContentTypeRequestBody Body;

        public CreateContentTypeRequest()
        {
        }

        public CreateContentTypeRequest(ServiceReference1.CreateContentTypeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CreateContentTypeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string displayName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string parentType;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement fields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public System.Xml.Linq.XElement contentTypeProperties;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public string addToView;

        public CreateContentTypeRequestBody()
        {
        }

        public CreateContentTypeRequestBody(string listName, string displayName, string parentType, System.Xml.Linq.XElement fields, System.Xml.Linq.XElement contentTypeProperties, string addToView)
        {
            this.listName = listName;
            this.displayName = displayName;
            this.parentType = parentType;
            this.fields = fields;
            this.contentTypeProperties = contentTypeProperties;
            this.addToView = addToView;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class CreateContentTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "CreateContentTypeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.CreateContentTypeResponseBody Body;

        public CreateContentTypeResponse()
        {
        }

        public CreateContentTypeResponse(ServiceReference1.CreateContentTypeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class CreateContentTypeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string CreateContentTypeResult;

        public CreateContentTypeResponseBody()
        {
        }

        public CreateContentTypeResponseBody(string CreateContentTypeResult)
        {
            this.CreateContentTypeResult = CreateContentTypeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentType", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypeRequestBody Body;

        public UpdateContentTypeRequest()
        {
        }

        public UpdateContentTypeRequest(ServiceReference1.UpdateContentTypeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement contentTypeProperties;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public System.Xml.Linq.XElement newFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public System.Xml.Linq.XElement updateFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public System.Xml.Linq.XElement deleteFields;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 6)]
        public string addToView;

        public UpdateContentTypeRequestBody()
        {
        }

        public UpdateContentTypeRequestBody(string listName, string contentTypeId, System.Xml.Linq.XElement contentTypeProperties, System.Xml.Linq.XElement newFields, System.Xml.Linq.XElement updateFields, System.Xml.Linq.XElement deleteFields, string addToView)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
            this.contentTypeProperties = contentTypeProperties;
            this.newFields = newFields;
            this.updateFields = updateFields;
            this.deleteFields = deleteFields;
            this.addToView = addToView;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentTypeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypeResponseBody Body;

        public UpdateContentTypeResponse()
        {
        }

        public UpdateContentTypeResponse(ServiceReference1.UpdateContentTypeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateContentTypeResult;

        public UpdateContentTypeResponseBody()
        {
        }

        public UpdateContentTypeResponseBody(System.Xml.Linq.XElement UpdateContentTypeResult)
        {
            this.UpdateContentTypeResult = UpdateContentTypeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteContentTypeRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteContentType", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteContentTypeRequestBody Body;

        public DeleteContentTypeRequest()
        {
        }

        public DeleteContentTypeRequest(ServiceReference1.DeleteContentTypeRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteContentTypeRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        public DeleteContentTypeRequestBody()
        {
        }

        public DeleteContentTypeRequestBody(string listName, string contentTypeId)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteContentTypeResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteContentTypeResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteContentTypeResponseBody Body;

        public DeleteContentTypeResponse()
        {
        }

        public DeleteContentTypeResponse(ServiceReference1.DeleteContentTypeResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteContentTypeResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement DeleteContentTypeResult;

        public DeleteContentTypeResponseBody()
        {
        }

        public DeleteContentTypeResponseBody(System.Xml.Linq.XElement DeleteContentTypeResult)
        {
            this.DeleteContentTypeResult = DeleteContentTypeResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypeXmlDocumentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentTypeXmlDocument", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypeXmlDocumentRequestBody Body;

        public UpdateContentTypeXmlDocumentRequest()
        {
        }

        public UpdateContentTypeXmlDocumentRequest(ServiceReference1.UpdateContentTypeXmlDocumentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypeXmlDocumentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public System.Xml.Linq.XElement newDocument;

        public UpdateContentTypeXmlDocumentRequestBody()
        {
        }

        public UpdateContentTypeXmlDocumentRequestBody(string listName, string contentTypeId, System.Xml.Linq.XElement newDocument)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
            this.newDocument = newDocument;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypeXmlDocumentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentTypeXmlDocumentResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypeXmlDocumentResponseBody Body;

        public UpdateContentTypeXmlDocumentResponse()
        {
        }

        public UpdateContentTypeXmlDocumentResponse(ServiceReference1.UpdateContentTypeXmlDocumentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypeXmlDocumentResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateContentTypeXmlDocumentResult;

        public UpdateContentTypeXmlDocumentResponseBody()
        {
        }

        public UpdateContentTypeXmlDocumentResponseBody(System.Xml.Linq.XElement UpdateContentTypeXmlDocumentResult)
        {
            this.UpdateContentTypeXmlDocumentResult = UpdateContentTypeXmlDocumentResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypesXmlDocumentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentTypesXmlDocument", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypesXmlDocumentRequestBody Body;

        public UpdateContentTypesXmlDocumentRequest()
        {
        }

        public UpdateContentTypesXmlDocumentRequest(ServiceReference1.UpdateContentTypesXmlDocumentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypesXmlDocumentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public System.Xml.Linq.XElement newDocument;

        public UpdateContentTypesXmlDocumentRequestBody()
        {
        }

        public UpdateContentTypesXmlDocumentRequestBody(string listName, System.Xml.Linq.XElement newDocument)
        {
            this.listName = listName;
            this.newDocument = newDocument;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class UpdateContentTypesXmlDocumentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "UpdateContentTypesXmlDocumentResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.UpdateContentTypesXmlDocumentResponseBody Body;

        public UpdateContentTypesXmlDocumentResponse()
        {
        }

        public UpdateContentTypesXmlDocumentResponse(ServiceReference1.UpdateContentTypesXmlDocumentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class UpdateContentTypesXmlDocumentResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement UpdateContentTypesXmlDocumentResult;

        public UpdateContentTypesXmlDocumentResponseBody()
        {
        }

        public UpdateContentTypesXmlDocumentResponseBody(System.Xml.Linq.XElement UpdateContentTypesXmlDocumentResult)
        {
            this.UpdateContentTypesXmlDocumentResult = UpdateContentTypesXmlDocumentResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteContentTypeXmlDocumentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteContentTypeXmlDocument", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteContentTypeXmlDocumentRequestBody Body;

        public DeleteContentTypeXmlDocumentRequest()
        {
        }

        public DeleteContentTypeXmlDocumentRequest(ServiceReference1.DeleteContentTypeXmlDocumentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteContentTypeXmlDocumentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string listName;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string documentUri;

        public DeleteContentTypeXmlDocumentRequestBody()
        {
        }

        public DeleteContentTypeXmlDocumentRequestBody(string listName, string contentTypeId, string documentUri)
        {
            this.listName = listName;
            this.contentTypeId = contentTypeId;
            this.documentUri = documentUri;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class DeleteContentTypeXmlDocumentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "DeleteContentTypeXmlDocumentResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.DeleteContentTypeXmlDocumentResponseBody Body;

        public DeleteContentTypeXmlDocumentResponse()
        {
        }

        public DeleteContentTypeXmlDocumentResponse(ServiceReference1.DeleteContentTypeXmlDocumentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class DeleteContentTypeXmlDocumentResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement DeleteContentTypeXmlDocumentResult;

        public DeleteContentTypeXmlDocumentResponseBody()
        {
        }

        public DeleteContentTypeXmlDocumentResponseBody(System.Xml.Linq.XElement DeleteContentTypeXmlDocumentResult)
        {
            this.DeleteContentTypeXmlDocumentResult = DeleteContentTypeXmlDocumentResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ApplyContentTypeToListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ApplyContentTypeToList", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.ApplyContentTypeToListRequestBody Body;

        public ApplyContentTypeToListRequest()
        {
        }

        public ApplyContentTypeToListRequest(ServiceReference1.ApplyContentTypeToListRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class ApplyContentTypeToListRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string webUrl;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string contentTypeId;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string listName;

        public ApplyContentTypeToListRequestBody()
        {
        }

        public ApplyContentTypeToListRequestBody(string webUrl, string contentTypeId, string listName)
        {
            this.webUrl = webUrl;
            this.contentTypeId = contentTypeId;
            this.listName = listName;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ApplyContentTypeToListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ApplyContentTypeToListResponse", Namespace = "http://schemas.microsoft.com/sharepoint/soap/", Order = 0)]
        public ServiceReference1.ApplyContentTypeToListResponseBody Body;

        public ApplyContentTypeToListResponse()
        {
        }

        public ApplyContentTypeToListResponse(ServiceReference1.ApplyContentTypeToListResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class ApplyContentTypeToListResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public System.Xml.Linq.XElement ApplyContentTypeToListResult;

        public ApplyContentTypeToListResponseBody()
        {
        }

        public ApplyContentTypeToListResponseBody(System.Xml.Linq.XElement ApplyContentTypeToListResult)
        {
            this.ApplyContentTypeToListResult = ApplyContentTypeToListResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface ListsSoapChannel : ServiceReference1.ListsSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class ListsSoapClient : System.ServiceModel.ClientBase<ServiceReference1.ListsSoap>, ServiceReference1.ListsSoap
    {

        /// <summary>
        /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
        /// </summary>
        /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
        /// <param name="clientCredentials">Учетные данные клиента.</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public ListsSoapClient(EndpointConfiguration endpointConfiguration) :
                base(ListsSoapClient.GetBindingForEndpoint(endpointConfiguration), ListsSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ListsSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(ListsSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ListsSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(ListsSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ListsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListResponse> ServiceReference1.ListsSoap.GetListAsync(ServiceReference1.GetListRequest request)
        {
            return base.Channel.GetListAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListResponse> GetListAsync(string listName)
        {
            ServiceReference1.GetListRequest inValue = new ServiceReference1.GetListRequest();
            inValue.Body = new ServiceReference1.GetListRequestBody();
            inValue.Body.listName = listName;
            return ((ServiceReference1.ListsSoap)(this)).GetListAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListAndViewResponse> ServiceReference1.ListsSoap.GetListAndViewAsync(ServiceReference1.GetListAndViewRequest request)
        {
            return base.Channel.GetListAndViewAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListAndViewResponse> GetListAndViewAsync(string listName, string viewName)
        {
            ServiceReference1.GetListAndViewRequest inValue = new ServiceReference1.GetListAndViewRequest();
            inValue.Body = new ServiceReference1.GetListAndViewRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.viewName = viewName;
            return ((ServiceReference1.ListsSoap)(this)).GetListAndViewAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DeleteListResponse> ServiceReference1.ListsSoap.DeleteListAsync(ServiceReference1.DeleteListRequest request)
        {
            return base.Channel.DeleteListAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.DeleteListResponse> DeleteListAsync(string listName)
        {
            ServiceReference1.DeleteListRequest inValue = new ServiceReference1.DeleteListRequest();
            inValue.Body = new ServiceReference1.DeleteListRequestBody();
            inValue.Body.listName = listName;
            return ((ServiceReference1.ListsSoap)(this)).DeleteListAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AddListResponse> ServiceReference1.ListsSoap.AddListAsync(ServiceReference1.AddListRequest request)
        {
            return base.Channel.AddListAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.AddListResponse> AddListAsync(string listName, string description, int templateID)
        {
            ServiceReference1.AddListRequest inValue = new ServiceReference1.AddListRequest();
            inValue.Body = new ServiceReference1.AddListRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.description = description;
            inValue.Body.templateID = templateID;
            return ((ServiceReference1.ListsSoap)(this)).AddListAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AddListFromFeatureResponse> ServiceReference1.ListsSoap.AddListFromFeatureAsync(ServiceReference1.AddListFromFeatureRequest request)
        {
            return base.Channel.AddListFromFeatureAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.AddListFromFeatureResponse> AddListFromFeatureAsync(string listName, string description, string featureID, int templateID)
        {
            ServiceReference1.AddListFromFeatureRequest inValue = new ServiceReference1.AddListFromFeatureRequest();
            inValue.Body = new ServiceReference1.AddListFromFeatureRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.description = description;
            inValue.Body.featureID = featureID;
            inValue.Body.templateID = templateID;
            return ((ServiceReference1.ListsSoap)(this)).AddListFromFeatureAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListResponse> ServiceReference1.ListsSoap.UpdateListAsync(ServiceReference1.UpdateListRequest request)
        {
            return base.Channel.UpdateListAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateListResponse> UpdateListAsync(string listName, System.Xml.Linq.XElement listProperties, System.Xml.Linq.XElement newFields, System.Xml.Linq.XElement updateFields, System.Xml.Linq.XElement deleteFields, string listVersion)
        {
            ServiceReference1.UpdateListRequest inValue = new ServiceReference1.UpdateListRequest();
            inValue.Body = new ServiceReference1.UpdateListRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.listProperties = listProperties;
            inValue.Body.newFields = newFields;
            inValue.Body.updateFields = updateFields;
            inValue.Body.deleteFields = deleteFields;
            inValue.Body.listVersion = listVersion;
            return ((ServiceReference1.ListsSoap)(this)).UpdateListAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListCollectionResponse> ServiceReference1.ListsSoap.GetListCollectionAsync(ServiceReference1.GetListCollectionRequest request)
        {
            return base.Channel.GetListCollectionAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListCollectionResponse> GetListCollectionAsync()
        {
            ServiceReference1.GetListCollectionRequest inValue = new ServiceReference1.GetListCollectionRequest();
            inValue.Body = new ServiceReference1.GetListCollectionRequestBody();
            return ((ServiceReference1.ListsSoap)(this)).GetListCollectionAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemsResponse> ServiceReference1.ListsSoap.GetListItemsAsync(ServiceReference1.GetListItemsRequest request)
        {
            return base.Channel.GetListItemsAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListItemsResponse> GetListItemsAsync(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string webID)
        {
            ServiceReference1.GetListItemsRequest inValue = new ServiceReference1.GetListItemsRequest();
            inValue.Body = new ServiceReference1.GetListItemsRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.viewName = viewName;
            inValue.Body.query = query;
            inValue.Body.viewFields = viewFields;
            inValue.Body.rowLimit = rowLimit;
            inValue.Body.queryOptions = queryOptions;
            inValue.Body.webID = webID;
            return ((ServiceReference1.ListsSoap)(this)).GetListItemsAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesResponse> ServiceReference1.ListsSoap.GetListItemChangesAsync(ServiceReference1.GetListItemChangesRequest request)
        {
            return base.Channel.GetListItemChangesAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesResponse> GetListItemChangesAsync(string listName, System.Xml.Linq.XElement viewFields, string since, System.Xml.Linq.XElement contains)
        {
            ServiceReference1.GetListItemChangesRequest inValue = new ServiceReference1.GetListItemChangesRequest();
            inValue.Body = new ServiceReference1.GetListItemChangesRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.viewFields = viewFields;
            inValue.Body.since = since;
            inValue.Body.contains = contains;
            return ((ServiceReference1.ListsSoap)(this)).GetListItemChangesAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesWithKnowledgeResponse> ServiceReference1.ListsSoap.GetListItemChangesWithKnowledgeAsync(ServiceReference1.GetListItemChangesWithKnowledgeRequest request)
        {
            return base.Channel.GetListItemChangesWithKnowledgeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesWithKnowledgeResponse> GetListItemChangesWithKnowledgeAsync(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string syncScope, System.Xml.Linq.XElement knowledge, System.Xml.Linq.XElement contains)
        {
            ServiceReference1.GetListItemChangesWithKnowledgeRequest inValue = new ServiceReference1.GetListItemChangesWithKnowledgeRequest();
            inValue.Body = new ServiceReference1.GetListItemChangesWithKnowledgeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.viewName = viewName;
            inValue.Body.query = query;
            inValue.Body.viewFields = viewFields;
            inValue.Body.rowLimit = rowLimit;
            inValue.Body.queryOptions = queryOptions;
            inValue.Body.syncScope = syncScope;
            inValue.Body.knowledge = knowledge;
            inValue.Body.contains = contains;
            return ((ServiceReference1.ListsSoap)(this)).GetListItemChangesWithKnowledgeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesSinceTokenResponse> ServiceReference1.ListsSoap.GetListItemChangesSinceTokenAsync(ServiceReference1.GetListItemChangesSinceTokenRequest request)
        {
            return base.Channel.GetListItemChangesSinceTokenAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListItemChangesSinceTokenResponse> GetListItemChangesSinceTokenAsync(string listName, string viewName, System.Xml.Linq.XElement query, System.Xml.Linq.XElement viewFields, string rowLimit, System.Xml.Linq.XElement queryOptions, string changeToken, System.Xml.Linq.XElement contains)
        {
            ServiceReference1.GetListItemChangesSinceTokenRequest inValue = new ServiceReference1.GetListItemChangesSinceTokenRequest();
            inValue.Body = new ServiceReference1.GetListItemChangesSinceTokenRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.viewName = viewName;
            inValue.Body.query = query;
            inValue.Body.viewFields = viewFields;
            inValue.Body.rowLimit = rowLimit;
            inValue.Body.queryOptions = queryOptions;
            inValue.Body.changeToken = changeToken;
            inValue.Body.contains = contains;
            return ((ServiceReference1.ListsSoap)(this)).GetListItemChangesSinceTokenAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsResponse> ServiceReference1.ListsSoap.UpdateListItemsAsync(ServiceReference1.UpdateListItemsRequest request)
        {
            return base.Channel.UpdateListItemsAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsResponse> UpdateListItemsAsync(string listName, System.Xml.Linq.XElement updates)
        {
            ServiceReference1.UpdateListItemsRequest inValue = new ServiceReference1.UpdateListItemsRequest();
            inValue.Body = new ServiceReference1.UpdateListItemsRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.updates = updates;
            return ((ServiceReference1.ListsSoap)(this)).UpdateListItemsAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsWithKnowledgeResponse> ServiceReference1.ListsSoap.UpdateListItemsWithKnowledgeAsync(ServiceReference1.UpdateListItemsWithKnowledgeRequest request)
        {
            return base.Channel.UpdateListItemsWithKnowledgeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateListItemsWithKnowledgeResponse> UpdateListItemsWithKnowledgeAsync(string listName, System.Xml.Linq.XElement updates, string syncScope, System.Xml.Linq.XElement knowledge)
        {
            ServiceReference1.UpdateListItemsWithKnowledgeRequest inValue = new ServiceReference1.UpdateListItemsWithKnowledgeRequest();
            inValue.Body = new ServiceReference1.UpdateListItemsWithKnowledgeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.updates = updates;
            inValue.Body.syncScope = syncScope;
            inValue.Body.knowledge = knowledge;
            return ((ServiceReference1.ListsSoap)(this)).UpdateListItemsWithKnowledgeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AddDiscussionBoardItemResponse> ServiceReference1.ListsSoap.AddDiscussionBoardItemAsync(ServiceReference1.AddDiscussionBoardItemRequest request)
        {
            return base.Channel.AddDiscussionBoardItemAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.AddDiscussionBoardItemResponse> AddDiscussionBoardItemAsync(string listName, byte[] message)
        {
            ServiceReference1.AddDiscussionBoardItemRequest inValue = new ServiceReference1.AddDiscussionBoardItemRequest();
            inValue.Body = new ServiceReference1.AddDiscussionBoardItemRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.message = message;
            return ((ServiceReference1.ListsSoap)(this)).AddDiscussionBoardItemAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AddWikiPageResponse> ServiceReference1.ListsSoap.AddWikiPageAsync(ServiceReference1.AddWikiPageRequest request)
        {
            return base.Channel.AddWikiPageAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.AddWikiPageResponse> AddWikiPageAsync(string strListName, string listRelPageUrl, string wikiContent)
        {
            ServiceReference1.AddWikiPageRequest inValue = new ServiceReference1.AddWikiPageRequest();
            inValue.Body = new ServiceReference1.AddWikiPageRequestBody();
            inValue.Body.strListName = strListName;
            inValue.Body.listRelPageUrl = listRelPageUrl;
            inValue.Body.wikiContent = wikiContent;
            return ((ServiceReference1.ListsSoap)(this)).AddWikiPageAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetVersionCollectionResponse> ServiceReference1.ListsSoap.GetVersionCollectionAsync(ServiceReference1.GetVersionCollectionRequest request)
        {
            return base.Channel.GetVersionCollectionAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetVersionCollectionResponse> GetVersionCollectionAsync(string strlistID, string strlistItemID, string strFieldName)
        {
            ServiceReference1.GetVersionCollectionRequest inValue = new ServiceReference1.GetVersionCollectionRequest();
            inValue.Body = new ServiceReference1.GetVersionCollectionRequestBody();
            inValue.Body.strlistID = strlistID;
            inValue.Body.strlistItemID = strlistItemID;
            inValue.Body.strFieldName = strFieldName;
            return ((ServiceReference1.ListsSoap)(this)).GetVersionCollectionAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AddAttachmentResponse> ServiceReference1.ListsSoap.AddAttachmentAsync(ServiceReference1.AddAttachmentRequest request)
        {
            return base.Channel.AddAttachmentAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.AddAttachmentResponse> AddAttachmentAsync(string listName, string listItemID, string fileName, byte[] attachment)
        {
            ServiceReference1.AddAttachmentRequest inValue = new ServiceReference1.AddAttachmentRequest();
            inValue.Body = new ServiceReference1.AddAttachmentRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.listItemID = listItemID;
            inValue.Body.fileName = fileName;
            inValue.Body.attachment = attachment;
            return ((ServiceReference1.ListsSoap)(this)).AddAttachmentAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetAttachmentCollectionResponse> ServiceReference1.ListsSoap.GetAttachmentCollectionAsync(ServiceReference1.GetAttachmentCollectionRequest request)
        {
            return base.Channel.GetAttachmentCollectionAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetAttachmentCollectionResponse> GetAttachmentCollectionAsync(string listName, string listItemID)
        {
            ServiceReference1.GetAttachmentCollectionRequest inValue = new ServiceReference1.GetAttachmentCollectionRequest();
            inValue.Body = new ServiceReference1.GetAttachmentCollectionRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.listItemID = listItemID;
            return ((ServiceReference1.ListsSoap)(this)).GetAttachmentCollectionAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DeleteAttachmentResponse> ServiceReference1.ListsSoap.DeleteAttachmentAsync(ServiceReference1.DeleteAttachmentRequest request)
        {
            return base.Channel.DeleteAttachmentAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.DeleteAttachmentResponse> DeleteAttachmentAsync(string listName, string listItemID, string url)
        {
            ServiceReference1.DeleteAttachmentRequest inValue = new ServiceReference1.DeleteAttachmentRequest();
            inValue.Body = new ServiceReference1.DeleteAttachmentRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.listItemID = listItemID;
            inValue.Body.url = url;
            return ((ServiceReference1.ListsSoap)(this)).DeleteAttachmentAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.CheckOutFileResponse> ServiceReference1.ListsSoap.CheckOutFileAsync(ServiceReference1.CheckOutFileRequest request)
        {
            return base.Channel.CheckOutFileAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.CheckOutFileResponse> CheckOutFileAsync(string pageUrl, string checkoutToLocal, string lastmodified)
        {
            ServiceReference1.CheckOutFileRequest inValue = new ServiceReference1.CheckOutFileRequest();
            inValue.Body = new ServiceReference1.CheckOutFileRequestBody();
            inValue.Body.pageUrl = pageUrl;
            inValue.Body.checkoutToLocal = checkoutToLocal;
            inValue.Body.lastmodified = lastmodified;
            return ((ServiceReference1.ListsSoap)(this)).CheckOutFileAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UndoCheckOutResponse> ServiceReference1.ListsSoap.UndoCheckOutAsync(ServiceReference1.UndoCheckOutRequest request)
        {
            return base.Channel.UndoCheckOutAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UndoCheckOutResponse> UndoCheckOutAsync(string pageUrl)
        {
            ServiceReference1.UndoCheckOutRequest inValue = new ServiceReference1.UndoCheckOutRequest();
            inValue.Body = new ServiceReference1.UndoCheckOutRequestBody();
            inValue.Body.pageUrl = pageUrl;
            return ((ServiceReference1.ListsSoap)(this)).UndoCheckOutAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.CheckInFileResponse> ServiceReference1.ListsSoap.CheckInFileAsync(ServiceReference1.CheckInFileRequest request)
        {
            return base.Channel.CheckInFileAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.CheckInFileResponse> CheckInFileAsync(string pageUrl, string comment, string CheckinType)
        {
            ServiceReference1.CheckInFileRequest inValue = new ServiceReference1.CheckInFileRequest();
            inValue.Body = new ServiceReference1.CheckInFileRequestBody();
            inValue.Body.pageUrl = pageUrl;
            inValue.Body.comment = comment;
            inValue.Body.CheckinType = CheckinType;
            return ((ServiceReference1.ListsSoap)(this)).CheckInFileAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesResponse> ServiceReference1.ListsSoap.GetListContentTypesAsync(ServiceReference1.GetListContentTypesRequest request)
        {
            return base.Channel.GetListContentTypesAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesResponse> GetListContentTypesAsync(string listName, string contentTypeId)
        {
            ServiceReference1.GetListContentTypesRequest inValue = new ServiceReference1.GetListContentTypesRequest();
            inValue.Body = new ServiceReference1.GetListContentTypesRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            return ((ServiceReference1.ListsSoap)(this)).GetListContentTypesAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesAndPropertiesResponse> ServiceReference1.ListsSoap.GetListContentTypesAndPropertiesAsync(ServiceReference1.GetListContentTypesAndPropertiesRequest request)
        {
            return base.Channel.GetListContentTypesAndPropertiesAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListContentTypesAndPropertiesResponse> GetListContentTypesAndPropertiesAsync(string listName, string contentTypeId, string propertyPrefix, bool includeWebProperties)
        {
            ServiceReference1.GetListContentTypesAndPropertiesRequest inValue = new ServiceReference1.GetListContentTypesAndPropertiesRequest();
            inValue.Body = new ServiceReference1.GetListContentTypesAndPropertiesRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            inValue.Body.propertyPrefix = propertyPrefix;
            inValue.Body.includeWebProperties = includeWebProperties;
            return ((ServiceReference1.ListsSoap)(this)).GetListContentTypesAndPropertiesAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetListContentTypeResponse> ServiceReference1.ListsSoap.GetListContentTypeAsync(ServiceReference1.GetListContentTypeRequest request)
        {
            return base.Channel.GetListContentTypeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.GetListContentTypeResponse> GetListContentTypeAsync(string listName, string contentTypeId)
        {
            ServiceReference1.GetListContentTypeRequest inValue = new ServiceReference1.GetListContentTypeRequest();
            inValue.Body = new ServiceReference1.GetListContentTypeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            return ((ServiceReference1.ListsSoap)(this)).GetListContentTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.CreateContentTypeResponse> ServiceReference1.ListsSoap.CreateContentTypeAsync(ServiceReference1.CreateContentTypeRequest request)
        {
            return base.Channel.CreateContentTypeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.CreateContentTypeResponse> CreateContentTypeAsync(string listName, string displayName, string parentType, System.Xml.Linq.XElement fields, System.Xml.Linq.XElement contentTypeProperties, string addToView)
        {
            ServiceReference1.CreateContentTypeRequest inValue = new ServiceReference1.CreateContentTypeRequest();
            inValue.Body = new ServiceReference1.CreateContentTypeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.displayName = displayName;
            inValue.Body.parentType = parentType;
            inValue.Body.fields = fields;
            inValue.Body.contentTypeProperties = contentTypeProperties;
            inValue.Body.addToView = addToView;
            return ((ServiceReference1.ListsSoap)(this)).CreateContentTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeResponse> ServiceReference1.ListsSoap.UpdateContentTypeAsync(ServiceReference1.UpdateContentTypeRequest request)
        {
            return base.Channel.UpdateContentTypeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeResponse> UpdateContentTypeAsync(string listName, string contentTypeId, System.Xml.Linq.XElement contentTypeProperties, System.Xml.Linq.XElement newFields, System.Xml.Linq.XElement updateFields, System.Xml.Linq.XElement deleteFields, string addToView)
        {
            ServiceReference1.UpdateContentTypeRequest inValue = new ServiceReference1.UpdateContentTypeRequest();
            inValue.Body = new ServiceReference1.UpdateContentTypeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            inValue.Body.contentTypeProperties = contentTypeProperties;
            inValue.Body.newFields = newFields;
            inValue.Body.updateFields = updateFields;
            inValue.Body.deleteFields = deleteFields;
            inValue.Body.addToView = addToView;
            return ((ServiceReference1.ListsSoap)(this)).UpdateContentTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeResponse> ServiceReference1.ListsSoap.DeleteContentTypeAsync(ServiceReference1.DeleteContentTypeRequest request)
        {
            return base.Channel.DeleteContentTypeAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeResponse> DeleteContentTypeAsync(string listName, string contentTypeId)
        {
            ServiceReference1.DeleteContentTypeRequest inValue = new ServiceReference1.DeleteContentTypeRequest();
            inValue.Body = new ServiceReference1.DeleteContentTypeRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            return ((ServiceReference1.ListsSoap)(this)).DeleteContentTypeAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeXmlDocumentResponse> ServiceReference1.ListsSoap.UpdateContentTypeXmlDocumentAsync(ServiceReference1.UpdateContentTypeXmlDocumentRequest request)
        {
            return base.Channel.UpdateContentTypeXmlDocumentAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypeXmlDocumentResponse> UpdateContentTypeXmlDocumentAsync(string listName, string contentTypeId, System.Xml.Linq.XElement newDocument)
        {
            ServiceReference1.UpdateContentTypeXmlDocumentRequest inValue = new ServiceReference1.UpdateContentTypeXmlDocumentRequest();
            inValue.Body = new ServiceReference1.UpdateContentTypeXmlDocumentRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            inValue.Body.newDocument = newDocument;
            return ((ServiceReference1.ListsSoap)(this)).UpdateContentTypeXmlDocumentAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypesXmlDocumentResponse> ServiceReference1.ListsSoap.UpdateContentTypesXmlDocumentAsync(ServiceReference1.UpdateContentTypesXmlDocumentRequest request)
        {
            return base.Channel.UpdateContentTypesXmlDocumentAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.UpdateContentTypesXmlDocumentResponse> UpdateContentTypesXmlDocumentAsync(string listName, System.Xml.Linq.XElement newDocument)
        {
            ServiceReference1.UpdateContentTypesXmlDocumentRequest inValue = new ServiceReference1.UpdateContentTypesXmlDocumentRequest();
            inValue.Body = new ServiceReference1.UpdateContentTypesXmlDocumentRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.newDocument = newDocument;
            return ((ServiceReference1.ListsSoap)(this)).UpdateContentTypesXmlDocumentAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeXmlDocumentResponse> ServiceReference1.ListsSoap.DeleteContentTypeXmlDocumentAsync(ServiceReference1.DeleteContentTypeXmlDocumentRequest request)
        {
            return base.Channel.DeleteContentTypeXmlDocumentAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.DeleteContentTypeXmlDocumentResponse> DeleteContentTypeXmlDocumentAsync(string listName, string contentTypeId, string documentUri)
        {
            ServiceReference1.DeleteContentTypeXmlDocumentRequest inValue = new ServiceReference1.DeleteContentTypeXmlDocumentRequest();
            inValue.Body = new ServiceReference1.DeleteContentTypeXmlDocumentRequestBody();
            inValue.Body.listName = listName;
            inValue.Body.contentTypeId = contentTypeId;
            inValue.Body.documentUri = documentUri;
            return ((ServiceReference1.ListsSoap)(this)).DeleteContentTypeXmlDocumentAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ApplyContentTypeToListResponse> ServiceReference1.ListsSoap.ApplyContentTypeToListAsync(ServiceReference1.ApplyContentTypeToListRequest request)
        {
            return base.Channel.ApplyContentTypeToListAsync(request);
        }

        public System.Threading.Tasks.Task<ServiceReference1.ApplyContentTypeToListResponse> ApplyContentTypeToListAsync(string webUrl, string contentTypeId, string listName)
        {
            ServiceReference1.ApplyContentTypeToListRequest inValue = new ServiceReference1.ApplyContentTypeToListRequest();
            inValue.Body = new ServiceReference1.ApplyContentTypeToListRequestBody();
            inValue.Body.webUrl = webUrl;
            inValue.Body.contentTypeId = contentTypeId;
            inValue.Body.listName = listName;
            return ((ServiceReference1.ListsSoap)(this)).ApplyContentTypeToListAsync(inValue);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ListsSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.ListsSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ListsSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.88.69:3333/_vti_bin/Lists.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.ListsSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.88.69:3333/_vti_bin/Lists.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }

        public enum EndpointConfiguration
        {

            ListsSoap,

            ListsSoap12,
        }
    }
}
