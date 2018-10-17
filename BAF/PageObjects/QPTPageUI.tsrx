<?xml version="1.0" encoding="utf-8"?>
<applicationModel>
  <name>QPTPageUI</name>
  <className>QPTPageUI</className>
  <description>QPTPageUI</description>
  <objects>
    <object technology="WPF" type="Window">
      <name>Qpt Explorer</name>
      <codeName>QptExplorerWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">Window</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="RadioButton">
          <name>Store</name>
          <codeName>StoreRadioButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Store</property>
              <property name="ObjectName" type="string">Store</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="RadioButton">
          <name>Online</name>
          <codeName>OnlineRadioButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Online</property>
              <property name="ObjectName" type="string">Online</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="RadioButton">
          <name>All</name>
          <codeName>AllRadioButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">All</property>
              <property name="ObjectName" type="string">All</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>File</name>
          <codeName>FileButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">File</property>
              <property name="ObjectName" type="string">PART_ToggleButton</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="TreeView">
          <name>_treeView</name>
          <codeName>TreeView</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">_treeView</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>closeQPTwindow</name>
          <codeName>closeQPTwindow</codeName>
          <description>closes the QPT window</description>
          <identification>
            <properties>
              <property name="ParentText" type="string" />
              <property name="Text" type="string" />
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;Window;</property>
              <property name="FullType" type="string">button</property>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
            </properties>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>New</name>
          <codeName>NewButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">New</property>
              <property name="ObjectName" type="string">PART_ToggleButton</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>ScrollViewer</name>
          <codeName>ScrollViewerUiObject</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">ScrollViewer</property>
              <property name="FullNamePath" type="string">ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Folder</name>
          <codeName>FolderUiObject</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">HomeGroup</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Common</name>
          <codeName>CommonUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">Common</property>
              <property name="FullNamePath" type="string">Common;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Filter</name>
          <codeName>FilterUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">Filter</property>
              <property name="FullNamePath" type="string">Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Quantification</name>
          <codeName>QuantificationUiObject</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">QuantificationGroup</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject</name>
          <codeName>WpfObjectUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;HomeGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>0</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject1</name>
          <codeName>WpfObjectUiObject1</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;HomeGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>New1</name>
          <codeName>NewFolder</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">New</property>
              <property name="ObjectName" type="string">New</property>
              <property name="FullType" type="string">button</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>New</name>
          <codeName>NewUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;New;;HomeGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Edit</name>
          <codeName>EditButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Edit</property>
              <property name="ObjectName" type="string">Edit</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Edit</name>
          <codeName>EditFolder</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Edit;;HomeGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Folder1</name>
          <codeName>FolderUiObject1</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">Folder</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject2</name>
          <codeName>WpfObjectUiObject2</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;Common;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Delete</name>
          <codeName>DeleteButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Delete</property>
              <property name="ObjectName" type="string">Delete</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Delete</name>
          <codeName>DeleteUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Delete;;Common;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Common1</name>
          <codeName>CommonUiObject1</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">Common</property>
              <property name="FullNamePath" type="string">Common;Common;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject3</name>
          <codeName>WpfObjectUiObject3</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Store</name>
          <codeName>StoreUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Store;;Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Online</name>
          <codeName>OnlineUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Online;;Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>All</name>
          <codeName>AllUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;All;;Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Filter1</name>
          <codeName>FilterUiObject1</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">Filter</property>
              <property name="FullNamePath" type="string">Filter;Filter;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject4</name>
          <codeName>WpfObjectUiObject4</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>0</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject5</name>
          <codeName>WpfObjectUiObject5</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject6</name>
          <codeName>WpfObjectUiObject6</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>2</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject7</name>
          <codeName>WpfObjectUiObject7</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>3</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject8</name>
          <codeName>WpfObjectUiObject8</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string" />
              <property name="FullNamePath" type="string">;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
            <index>4</index>
          </identification>
        </object>
        <object technology="WPF" type="Menu">
          <name>New</name>
          <codeName>NewMenu</codeName>
          <identification>
            <properties>
              <property name="NativeClass" type="string">Microsoft.Windows.Controls.Ribbon.RibbonMenuButton</property>
              <property name="ObjectName" type="string">New</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>New1</name>
          <codeName>NewUiObject1</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;PART_ToggleButton;New;;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Open</name>
          <codeName>OpenButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Open</property>
              <property name="ObjectName" type="string">Open</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Open</name>
          <codeName>OpenUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Open;;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Duplicate</name>
          <codeName>DuplicateButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Duplicate</property>
              <property name="ObjectName" type="string">Duplicate</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Duplicate</name>
          <codeName>DuplicateUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Duplicate;;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Rename</name>
          <codeName>RenameButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Rename</property>
              <property name="ObjectName" type="string">Rename</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Rename</name>
          <codeName>RenameUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Rename;;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Note</name>
          <codeName>NoteButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Note</property>
              <property name="ObjectName" type="string">Note</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Note</name>
          <codeName>NoteUiObject</codeName>
          <identification>
            <properties>
              <property name="WindowTitleRegExp" type="string">Qpt Explorer</property>
              <property name="ObjectName" type="string">TwoLineText</property>
              <property name="FullNamePath" type="string">TwoLineText;Note;;QuantificationGroup;ScrollViewer;Explorer;Ribbon;Window;</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Quantification1</name>
          <codeName>QuantificationUiObject1</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">Quantification</property>
              <property name="FullType" type="string">object</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>WpfWindow</name>
      <codeName>WpfWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string" />
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string" />
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="Image">
          <name>Exitbutton</name>
          <codeName>Image</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">Image</property>
              <property name="FullNamePath" type="string">Image;Exit;PART_SubMenuScrollViewer;</property>
              <property name="FullType" type="string">image</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Exit</name>
          <codeName>ExitUiObject</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">Exit</property>
              <property name="FullNamePath" type="string">Exit;Exit;PART_SubMenuScrollViewer;</property>
              <property name="FullType" type="string">object</property>
              <property name="WindowTitleRegExp" type="string" />
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Store One Season Quantification</name>
          <codeName>StoreOneSeasonQuantificationUiObject</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">Store One Season Quantification</property>
              <property name="FullNamePath" type="string">Store One Season Quantification;Store One Season Quantification;PART_SubMenuScrollViewer;</property>
              <property name="FullType" type="string">object</property>
              <property name="WindowTitleRegExp" type="string" />
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>QPT Error</name>
      <codeName>QPTErrorWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">QPT Error</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">QPT Error</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="Button">
          <name>Close</name>
          <codeName>CloseButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Close</property>
              <property name="ObjectName" type="string">Close</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>New Quantification</name>
      <codeName>NewQuantificationWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">New Quantification</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">New Quantification</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="EditField">
          <name>Name</name>
          <codeName>NameEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">_name</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Create</name>
          <codeName>CreateButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Create</property>
              <property name="ObjectName" type="string">Create</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>7-2018 / 1111 Eyes / 4-pack Eye shadows / 4-pack Eye shadows</name>
      <codeName>Eyes4PackEyeShadows4PackEyeShadowsWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">7-2018 / 1111 Eyes / 4-pack Eye shadows / 4-pack Eye shadows</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">7-2018 / 1111 Eyes / 4-pack Eye shadows / 4-pack Eye shadows</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="Button">
          <name>Save</name>
          <codeName>SaveButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Save</property>
              <property name="ObjectName" type="string">save</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>New Folder</name>
      <codeName>NewFolderWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">New Folder</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">New Folder</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="EditField">
          <name>_name</name>
          <codeName>NameEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">_name</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="EditField">
          <name>WpfEdit</name>
          <codeName>WpfEditEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string" />
              <property name="FullType" type="string">edit</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Save</name>
          <codeName>SaveButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Save</property>
              <property name="ObjectName" type="string">Save</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
    <object technology="WPF" type="Window">
      <name>Edit Folder</name>
      <codeName>EditFolderWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">Edit Folder</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">Edit Folder</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="EditField">
          <name>_name</name>
          <codeName>NameEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">_name</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="EditField">
          <name>WpfEdit</name>
          <codeName>WpfEditEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string" />
              <property name="FullType" type="string">edit</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Save</name>
          <codeName>SaveButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">Save</property>
              <property name="ObjectName" type="string">Save</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
  </objects>
</applicationModel>