﻿using DCL.Helpers;
using DCLServices.WearablesCatalogService;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DCL.Backpack
{
    public class BackpackFiltersController
    {
        public event Action<HashSet<string>> OnCollectionChanged;
        public event Action<(NftOrderByOperation type, bool directionAscendent)> OnSortByChanged;
        public event Action<string> OnSearchTextChanged;

        private const string DECENTRALAND_COLLECTION_ID = "decentraland";
        private const string BASE_WEARABLES_COLLECTION_ID = "base-wearables";

        private readonly IBackpackFiltersComponentView view;
        private bool collectionsAlreadyLoaded;
        private HashSet<string> selectedCollections = new();
        private bool isOnlyCollectiblesOn;

        public BackpackFiltersController(IBackpackFiltersComponentView view)
        {
            this.view = view;

            view.OnOnlyCollectiblesChanged += ChangeOnlyCollectibles;
            view.OnCollectionChanged += ChangeOnCollection;
            view.OnSortByChanged += ChangeSortBy;
            view.OnSearchTextChanged += ChangeSearchText;
        }

        public void Dispose()
        {
            view.OnOnlyCollectiblesChanged -= ChangeOnlyCollectibles;
            view.OnCollectionChanged -= ChangeOnCollection;
            view.OnSortByChanged -= ChangeSortBy;
            view.OnSearchTextChanged -= ChangeSearchText;

            view.Dispose();
        }

        public void LoadCollections()
        {
            if (collectionsAlreadyLoaded)
                return;

            WearablesFetchingHelper.GetThirdPartyCollections()
                                   .Then(collections =>
                                    {
                                        WearableCollectionsAPIData.Collection defaultCollection = new () { urn = DECENTRALAND_COLLECTION_ID, name = "Decentraland" };
                                        view.LoadCollectionDropdown(collections, defaultCollection);
                                        collectionsAlreadyLoaded = true;
                                    })
                                   .Catch((error) => Debug.LogError(error));
        }

        private void ChangeOnlyCollectibles(bool isOn)
        {
            isOnlyCollectiblesOn = isOn;

            selectedCollections.Remove(BASE_WEARABLES_COLLECTION_ID);
            if (!isOn)
                selectedCollections.Add(BASE_WEARABLES_COLLECTION_ID);

            OnCollectionChanged?.Invoke(selectedCollections);
        }

        private void ChangeOnCollection(HashSet<string> newSelectedCollections)
        {
            selectedCollections = newSelectedCollections;
            if (!isOnlyCollectiblesOn)
                selectedCollections.Add(BASE_WEARABLES_COLLECTION_ID);

            OnCollectionChanged?.Invoke(selectedCollections);
        }

        private void ChangeSortBy((NftOrderByOperation type, bool directionAscendent) newSorting) =>
            OnSortByChanged?.Invoke(newSorting);

        private void ChangeSearchText(string newText) =>
            OnSearchTextChanged?.Invoke(newText);
    }
}
